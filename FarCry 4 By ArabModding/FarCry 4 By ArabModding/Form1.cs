using PS3Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarCry_4_By_ArabModding
{
    public partial class Form1 : Form
    {
        public static PS3API AR = new PS3API();
        static uint GodMod = 0x4C0BB8,// 0x4C0BF8, // 1.5 0x4d3960,
            NoReload = 0x007A8E9C,// 0x7A8A9C,// 1.5 0x0781480,
            InfEqui = 0x68B100,// 1.6 0x68ADB0,//1.5 0x069fa74,
            InfMoney = 0x6AE0E4,//1.6 0x6BDCFC, // 1.5 0x06ba21c,
            MaxBullets = 0x6A16A0,// 1.6 0x6A12D0,// 1.5 0x069e298,
            MaxMoney = 0x6ADBD4,//0x6BD7EC,// 1.5 0x06ba0f4;
            XP = 0xE793E4; // 1.6 0xE88CC4;
        public Form1()
        {
            InitializeComponent();
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            AR.ChangeAPI(SelectAPI.ControlConsole);
            if (Connect1.Text == "Connect [ CEX ]")
            {
                if (AR.ConnectTarget())
                {
                    NBox1.Text = "Connected";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Success;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                    Connect1.Text = "Attach";
                }
                else
                {
                    NBox1.Text = "Can't Connect";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Error;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                }
            }
            else if (Connect1.Text == "Attach")
            {
                if (AR.AttachProcess())
                {
                    NBox1.Text = "Attached";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Success;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                    Connect1.Text = "DisConnect";
                }
                else
                {
                    NBox1.Text = "Can't Attach";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Error;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                }
            }
            else if (Connect1.Text == "DisConnect")
            {
                AR.DisconnectTarget();
                Connect1.Text = "Connect [ CEX ]";
            }
        }

        private void monoFlat_Button2_Click(object sender, EventArgs e)
        {
            if (Connect2.Text == "Connect [ DEX ]")
            {
                if (AR.ConnectTarget())
                {
                    NBox1.Text = "Connected";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Success;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                    Connect2.Text = "Attach";
                }
                else
                {
                    NBox1.Text = "Can't Connect";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Error;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                }
            }
            else if (Connect2.Text == "Attach")
            {
                if (AR.AttachProcess())
                {
                    NBox1.Text = "Attached";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Success;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                    Connect2.Text = "DisConnect";
                }
                else
                {
                    NBox1.Text = "Can't Attach";
                    NBox1.NotificationType = MonoFlat_NotificationBox.Type.Error;
                    NBox1.Refresh();
                    NBox1.Visible = true;
                }
            }
            else if (Connect2.Text == "DisConnect")
            {
                AR.DisconnectTarget();
                Connect2.Text = "Connect [ DEX ]";
            }
        }

        private void monoFlat_Button3_Click(object sender, EventArgs e)
        {
            if(GodModB.Text == "God Mode [ Off ]")
            {
                //FarCry.GodMode(true);
                AR.SetMemory(GodMod, new byte[] { 0xD0, 0x43, 0x00, 0x10 });
                GodModB.Text = "God Mode [ On ]";
            }
            else if (GodModB.Text == "God Mode [ On ]")
            {
                //FarCry.GodMode(false);
                AR.SetMemory(GodMod, new byte[] { 0x48, 0x00, 0x00, 0x04 });
                GodModB.Text = "God Mode [ Off ]";
            }
        }

        private void monoFlat_Button4_Click(object sender, EventArgs e)
        {
            AR.SetMemory(XP, new byte[] { 0x1F, 0xC4, 0x01, 0xF4 });
        }

        private void monoFlat_Button5_Click(object sender, EventArgs e)
        {
            if (AmmoB.Text == "Ammo + NoReload  [ Off ]")
            {
                //FarCry.Ammo(true);
                AR.SetMemory(NoReload, new byte[] { 0x7C, 0xA4, 0x2B, 0x78 });
                AmmoB.Text = "Ammo + NoReload  [ On ]";
            }
            else if (AmmoB.Text == "Ammo + NoReload  [ On ]")
            {
                AR.SetMemory(NoReload, new byte[] { 0x7C, 0x9F, 0x28, 0x10 });
                //FarCry.Ammo(false);
                AmmoB.Text = "Ammo + NoReload  [ Off ]";
            }
            
        }

        private void AmmoInClip_Click(object sender, EventArgs e)
        {
            if (AmmoInClip.Text == "Ammo In Clip [ Off ]")
            {
                AR.SetMemory(MaxBullets, new byte[] { 0x38, 0x80, 0x03, 0xE7 });
                //FarCry.AmmoInReload(true);
                AmmoInClip.Text = "Ammo In Clip [ On ]";
            }
            else if (AmmoInClip.Text == "Ammo In Clip [ On ]")
            {
                AR.SetMemory(MaxBullets, new byte[] { 0x7C, 0x83, 0x28, 0x10 });
                //FarCry.AmmoInReload(false);
                AmmoInClip.Text = "Ammo In Clip [ Off ]";
            }
        }

        private void InfItemsB_Click(object sender, EventArgs e)
        {
            if (InfItemsB.Text == "Inf Items [ Off ]")
            {
                //FarCry.InfItems(true);
                AR.SetMemory(InfEqui, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                Msg("Get new Equipment");
                InfItemsB.Text = "Inf Items [ On ]";
            }
            else if (InfItemsB.Text == "Inf Items [ On ]")
            {
                AR.SetMemory(InfEqui, new byte[] { 0x7C, 0x9F, 0x20, 0x10 });
            //    FarCry.InfItems(false);
                InfItemsB.Text = "Inf Items [ Off ]";
            }
        }

        private void SetMoneyB_Click(object sender, EventArgs e)
        {
            
            byte[] Money = BitConverter.GetBytes(Convert.ToUInt32(MoneyBox.Text));
            AR.SetMemory(InfMoney, Money);
            //FarCry.SetMoney(MoneyBox.Text);
        }

        private void MaxSkillB_Click(object sender, EventArgs e)
        {
            if (MaxSkillB.Text == "Max Skills")
            {
                //FarCry.MaxSkill(true);
                MaxSkillB.Text = "Defuault";
            }
            else if (MaxSkillB.Text == "Defuault")
            {
                MaxSkillB.Text = "Max Skills";
                //FarCry.MaxSkill(false);
            }
        }

        private void playUI_Button_N1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Far Cry 4  1.07\n\n\nBig Thanks To ArabModding Members To Be In Our Website.. <3\n\n\nMade By BISOON AM|A", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult Di = MessageBox.Show("We Hope You Join Us At ArabModding.com\n\nIf You Press Ok We Will Take You There ^_^", "About", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Di == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://www.arabmodding.com/ar/");
            }
        }
        void Msg(string msg)
        {
            MessageBox.Show(msg,"Message",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }
       
    }
}
