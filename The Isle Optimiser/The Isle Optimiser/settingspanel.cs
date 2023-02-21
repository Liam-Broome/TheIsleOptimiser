using System.Runtime.InteropServices;
using System.Text;

namespace The_Isle_Optimiser
{
    public partial class settingspanel : Form
    {
        public settingspanel()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern long WriteValueA(string strSection, string strKeyName, string strValue, string strFilePath);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetKeyValueA(string strSection, string strKeyName, string strEmpty, StringBuilder RetVal, int nSize, string strFilePath);

        public string GameUserSettingsLocation;

        private void Form1_Load(object sender, EventArgs e)
        {

            GameUserSettingsLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TheIsle\\Saved\\Config\\WindowsClient\\GameUserSettings.ini";

            if (File.Exists(GameUserSettingsLocation)) {
                _ = new FileInfo(GameUserSettingsLocation)
                {
                    IsReadOnly = false
                };

                StringBuilder temp = new(255);

                _ = GetKeyValueA("ScalabilityGroups", "sg.ResolutionQuality", string.Empty, temp, 255, GameUserSettingsLocation);

                ResolutionQuality.Value = Convert.ToInt32(Decimal.Round(Decimal.Parse(temp.ToString()), 1));

                _ = GetKeyValueA("ScalabilityGroups", "sg.ViewDistanceQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                ViewDistanceQuality.Value = Convert.ToInt32(temp.ToString());

                _ = GetKeyValueA("ScalabilityGroups", "sg.AntiAliasingQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                AntiAliasingQuality.Value = Convert.ToInt32(temp.ToString());

                _ = GetKeyValueA("ScalabilityGroups", "sg.ShadowQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                ShadowQuality.Value = Convert.ToInt32(temp.ToString());

                _ = GetKeyValueA("ScalabilityGroups", "sg.PostProcessQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                PostProcessQuality.Value = Convert.ToInt32(temp.ToString());

                _ = GetKeyValueA("ScalabilityGroups", "sg.TextureQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                TextureQuality.Value = Convert.ToInt32(temp.ToString());

                _ = GetKeyValueA("ScalabilityGroups", "sg.EffectsQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                EffectsQuality.Value = Convert.ToInt32(temp.ToString());

                _ = GetKeyValueA("ScalabilityGroups", "sg.FoliageQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                FoliageQuality.Value = Convert.ToInt32(temp.ToString());

                _ = GetKeyValueA("ScalabilityGroups", "sg.ShadingQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                ShadingQuality.Value = Convert.ToInt32(temp.ToString());


            }
        }

        private void ApplySettings_Click(object sender, EventArgs e)
        {
            WriteValueA("ScalabilityGroups", "sg.ResolutionQuality", ResolutionQuality.Value.ToString() , GameUserSettingsLocation);
            WriteValueA("ScalabilityGroups", "sg.ViewDistanceQuality", ViewDistanceQuality.Value.ToString(), GameUserSettingsLocation);
            WriteValueA("ScalabilityGroups", "sg.AntiAliasingQuality", AntiAliasingQuality.Value.ToString(), GameUserSettingsLocation);
            WriteValueA("ScalabilityGroups", "sg.ShadowQuality", ShadowQuality.Value.ToString(), GameUserSettingsLocation);
            WriteValueA("ScalabilityGroups", "sg.PostProcessQuality", PostProcessQuality.Value.ToString(), GameUserSettingsLocation);
            WriteValueA("ScalabilityGroups", "sg.EffectsQuality", EffectsQuality.Value.ToString(), GameUserSettingsLocation);
            WriteValueA("ScalabilityGroups", "sg.FoliageQuality", FoliageQuality.Value.ToString(), GameUserSettingsLocation);
            WriteValueA("ScalabilityGroups", "sg.ShadingQuality", ShadingQuality.Value.ToString(), GameUserSettingsLocation);

            _ = new FileInfo(GameUserSettingsLocation)
            {
                IsReadOnly = true
            };

            MessageBox.Show("Settings updated: Successful.");
        }
    }
}