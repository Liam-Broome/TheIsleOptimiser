using System.Runtime.InteropServices;
using System.Text;

namespace The_Isle_Optimiser
{
    public partial class settingspanel : Form
    {

        private const int MaxWriteValue = 10;
        public string gameUserSettingsPath;

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern long WriteValue(string strSection, string strKeyName, string strValue, string strFilePath);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetKeyValue(string strSection, string strKeyName, string strEmpty, StringBuilder RetVal, int nSize, string strFilePath);

        public settingspanel()
        {
            InitializeComponent();
            gameUserSettingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TheIsle", "Saved", "Config", "WindowsClient", "GameUserSettings.ini");
        }

        private static int GetIntFromSettingValueBuffer(StringBuilder settingValueBuffer)
        {
            return Convert.ToInt32(settingValueBuffer.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (File.Exists(gameUserSettingsPath))
            {
                //Setting the buffer for the max setting value.
                StringBuilder settingValueBuffer = new(MaxWriteValue);

                //Write Resolution Quality. 
                GetKeyValue("ScalabilityGroups", "sg.ResolutionQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                ResolutionQuality.Value = (int)Math.Round(double.Parse(settingValueBuffer.ToString()), 1);

                //Write View Distance Quality. 
                GetKeyValue("ScalabilityGroups", "sg.ViewDistanceQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                ViewDistanceQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);

                //Write Anti Aliasing Quality. 
                GetKeyValue("ScalabilityGroups", "sg.AntiAliasingQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                AntiAliasingQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);

                //Write Shadow Quality. 
                GetKeyValue("ScalabilityGroups", "sg.ShadowQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                ShadowQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);

                //Write Post Process Quality. 
                GetKeyValue("ScalabilityGroups", "sg.PostProcessQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                PostProcessQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);

                //Write Texture Quality. 
                GetKeyValue("ScalabilityGroups", "sg.TextureQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                TextureQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);

                //Write Effects Quality. 
                GetKeyValue("ScalabilityGroups", "sg.EffectsQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                EffectsQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);

                //Write Foliage Quality. 
                GetKeyValue("ScalabilityGroups", "sg.FoliageQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                FoliageQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);

                //Write Shading Quality. 
                GetKeyValue("ScalabilityGroups", "sg.ShadingQuality", string.Empty, settingValueBuffer, MaxWriteValue, gameUserSettingsPath);
                ShadingQuality.Value = GetIntFromSettingValueBuffer(settingValueBuffer);
            }
        }

        private void ApplySettings_Click(object sender, EventArgs e)
        {
            WriteValue("ScalabilityGroups", "sg.ResolutionQuality", ResolutionQuality.Value.ToString() , gameUserSettingsPath);
            WriteValue("ScalabilityGroups", "sg.ViewDistanceQuality", ViewDistanceQuality.Value.ToString(), gameUserSettingsPath);
            WriteValue("ScalabilityGroups", "sg.AntiAliasingQuality", AntiAliasingQuality.Value.ToString(), gameUserSettingsPath);
            WriteValue("ScalabilityGroups", "sg.ShadowQuality", ShadowQuality.Value.ToString(), gameUserSettingsPath);
            WriteValue("ScalabilityGroups", "sg.PostProcessQuality", PostProcessQuality.Value.ToString(), gameUserSettingsPath);
            WriteValue("ScalabilityGroups", "sg.EffectsQuality", EffectsQuality.Value.ToString(), gameUserSettingsPath);
            WriteValue("ScalabilityGroups", "sg.FoliageQuality", FoliageQuality.Value.ToString(), gameUserSettingsPath);
            WriteValue("ScalabilityGroups", "sg.ShadingQuality", ShadingQuality.Value.ToString(), gameUserSettingsPath);

            new FileInfo(gameUserSettingsPath) { IsReadOnly = true };

            MessageBox.Show("Settings updated: Successful.");
        }
    }
}