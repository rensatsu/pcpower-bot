using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace PCPowerBot
{
    public partial class MainForm : Form
    {
        private static TelegramBotClient bot;
        private bool botEnabled = false;

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

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.TextMessage) return;

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

            if (Properties.Settings.Default.ApiUser == "")
            {
                Properties.Settings.Default.ApiUser = message.From.Id.ToString();
                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.ApiUser != message.From.Id.ToString())
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Access denied");
                return;
            }

            if (message.Text.StartsWith("/power"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Turning your PC off");
                PowerControl.Shutdown();
            }
            else if (message.Text.StartsWith("/reboot") || message.Text.StartsWith("/restart"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Rebooting your PC");
                PowerControl.Reboot();
            }
            else if (message.Text.StartsWith("/sleep"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Putting your PC into sleep mode");
                PowerControl.Sleep();
            }
            else if (message.Text.StartsWith("/hibernate"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Putting your PC into hibernation");
                PowerControl.Hibernate();
            }
            else if (message.Text.StartsWith("/lock"))
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Locking your PC");
                PowerControl.Lock();
            }
            else
            {
                await bot.SendTextMessageAsync(message.Chat.Id, @"Unknown command");
            }
        }

        private async void MainForm_Load(object sender, EventArgs e)
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
                var me = await GetMyInfo();
                botNameBox.Text = me.Username;

                bot.StartReceiving();

                MinimizeTimer();
            }
            else
            {
                Opacity = 1;
            }

            trayIcon.Text = Text;
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
