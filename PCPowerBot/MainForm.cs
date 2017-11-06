using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PCPowerBot
{
    public partial class MainForm : Form
    {
        private static TelegramBotClient bot;
        private bool botEnabled = false;
        private enum LockScreenStatus : byte
        {
            Unknown = 0,
            Locked = 1,
            Unlocked = 2
        };

        private static LockScreenStatus isLocked = LockScreenStatus.Unknown;

        public MainForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.AppUpgraded)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.AppUpgraded = false;
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.ApiKey.Length > 0)
            {
                bot = new TelegramBotClient(Properties.Settings.Default.ApiKey);
                botEnabled = true;
            }

            Properties.Settings.Default.SettingsSaving += SettingsSavingEvent;
        }

        private void SettingsSavingEvent(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                if (botToken.Text != Properties.Settings.Default.ApiKey)
                {
                    botToken.Text = Properties.Settings.Default.ApiKey;
                }

                if (userIdBox.Text != Properties.Settings.Default.ApiUser)
                {
                    userIdBox.Text = Properties.Settings.Default.ApiUser;
                }
            });
        }

        private static ReplyKeyboardMarkup GetKeyboard()
        {
            return new ReplyKeyboardMarkup(new[]
            {
                new [] // top row
                {
                    new KeyboardButton("Lock")
                },
                new [] // middle row
                {
                    new KeyboardButton("Shutdown"),
                    new KeyboardButton("Reboot")
                },
                new [] // bottom row
                {
                    new KeyboardButton("Sleep"),
                    new KeyboardButton("Hibernate")
                }
            });
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            var keyboard = GetKeyboard();

            if (message == null || message.Type != MessageType.TextMessage) return;

            if (message.Text.StartsWith("/start"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Hello", replyMarkup: keyboard);
                return;
            }

            if (Properties.Settings.Default.ApiUser == "")
            {
                Properties.Settings.Default.ApiUser = message.From.Id.ToString();
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.ApiUser != message.From.Id.ToString())
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Access denied", replyMarkup: keyboard);
                return;
            }

            var timeDiff = (message.Date - DateTime.Now).TotalSeconds;

            if (timeDiff < 0 - Properties.Settings.Default.MaxDelay)
            {
                await bot.SendTextMessageAsync(
                    message.Chat.Id,
                    $"Refused to execute command:\n```{message.Text}```\nTime difference: {timeDiff.ToString()}",
                    ParseMode.Markdown
                );
                return;
            }

            if (message.Text.StartsWith("Shutdown") || message.Text.StartsWith("/power"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Turning your PC off", replyMarkup: keyboard);
                PowerControl.Shutdown();
            }
            else if (message.Text.StartsWith("Reboot") || message.Text.StartsWith("/reboot") || message.Text.StartsWith("/restart"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Rebooting your PC", replyMarkup: keyboard);
                PowerControl.Reboot();
            }
            else if (message.Text.StartsWith("Sleep") || message.Text.StartsWith("/sleep"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Putting your PC into sleep mode", replyMarkup: keyboard);
                PowerControl.Sleep();
            }
            else if (message.Text.StartsWith("Hibernate") || message.Text.StartsWith("/hibernate"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Putting your PC into hibernation", replyMarkup: keyboard);
                PowerControl.Hibernate();
            }
            else if (message.Text.StartsWith("Lock") || message.Text.StartsWith("/lock"))
            {
                string text = String.Empty;

                switch (isLocked)
                {
                    case LockScreenStatus.Locked:
                        text = @"Your PC is already locked";
                        break;
                    case LockScreenStatus.Unlocked:
                        text = @"Your PC is unlocked, locking";
                        break;
                    default:
                        text = @"Current lock status is unknown, locking";
                        break;
                }

                await bot.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: keyboard);
                PowerControl.Lock();
            }
            else
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Unknown command", replyMarkup: keyboard);
            }
        }

        private async void InitApp()
        {
            try
            {
                var me = await GetMyInfo();
                botNameBox.Text = me.Username;

                bot.StartReceiving();
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(500);
                InitApp();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            botToken.Text = Properties.Settings.Default.ApiKey;
            maxDelayBox.Text = Properties.Settings.Default.MaxDelay.ToString();
            userIdBox.Text = Properties.Settings.Default.ApiUser;

            var delayIdx = maxDelayBox.Items.IndexOf(Properties.Settings.Default.MaxDelay.ToString());
            if (delayIdx == -1)
            {
                maxDelayBox.SelectedIndex = 0;
            }
            else
            {
                maxDelayBox.SelectedIndex = delayIdx;
            }

            if (botEnabled)
            {
                bot.OnMessage += BotOnMessageReceived;

                InitApp();
                MinimizeTimer();
            }
            else
            {
                Opacity = 1;
            }

            trayIcon.Text = Text;

            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);
            isLocked = LockScreenStatus.Unlocked;
        }

        private void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == Microsoft.Win32.SessionSwitchReason.SessionLock)
            {
                isLocked = LockScreenStatus.Locked;
            }
            else if (e.Reason == Microsoft.Win32.SessionSwitchReason.SessionUnlock)
            {
                isLocked = LockScreenStatus.Unlocked;
            }
        }

        private void MinimizeTimer()
        {
            var aTimer = new System.Timers.Timer
            {
                Interval = 500,
                AutoReset = false
            };

            aTimer.Elapsed += (Object source, System.Timers.ElapsedEventArgs e) =>
            {
                Invoke((MethodInvoker)delegate
                {
                    this.WindowState = FormWindowState.Minimized;
                });
            };

            aTimer.Enabled = true;
        }

        static async Task<Telegram.Bot.Types.User> GetMyInfo()
        {
            var me = await bot.GetMeAsync();
            return me;
        }

        private void btnSaveToken_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ApiKey = botToken.Text;
            Properties.Settings.Default.Save();
            var res = MessageBox.Show("Application will restart", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (res == DialogResult.OK)
            {
                Application.Restart();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                bot.StopReceiving();
            }
            catch (Exception) { }
        }

        private void maxDelayBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Properties.Settings.Default.MaxDelay = Int32.Parse(maxDelayBox.Text);
                Properties.Settings.Default.Save();
            }
            catch (Exception) { }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ApiUser = userIdBox.Text.Trim();
            Properties.Settings.Default.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void ShowForm()
        {
            Show();
            WindowState = FormWindowState.Normal;
            BringToFront();
            Opacity = 1;
        }

        private void showApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void trayIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowForm();
        }
    }
}
