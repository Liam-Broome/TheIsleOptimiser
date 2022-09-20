using System.Runtime.InteropServices;
using System.Text;

namespace The_Isle_Optimiser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        public static extern long WriteValueA(string strSection, string strKeyName, string strValue, string strFilePath);

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        public static extern int GetKeyValueA(string strSection, string strKeyName, string strEmpty, StringBuilder RetVal, int nSize, string strFilePath);

        public string R_ResolutionQuality;
        public string R_ViewDistanceQuality;
        public string R_AntiAliasingQuality;
        public string R_ShadowQuality;
        public string R_PostProcessQuality;
        public string R_TextureQuality;
        public string R_EffectsQuality;
        public string R_FoliageQuality;
        public string R_ShadingQuality;

        private void Form1_Load(object sender, EventArgs e)
        {

            var GameUserSettingsLocation = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\TheIsle\\Saved\\Config\\WindowsClient\\GameUserSettings.ini";

            if (File.Exists(GameUserSettingsLocation)) {
                _ = new FileInfo(GameUserSettingsLocation)
                {
                    IsReadOnly = false
                };

                StringBuilder temp = new(255);

                _ = GetKeyValueA("ScalabilityGroups", "sg.ResolutionQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_ResolutionQuality = temp.ToString(); 

                _ = GetKeyValueA("ScalabilityGroups", "sg.ViewDistanceQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_ViewDistanceQuality = temp.ToString(); 

                _ = GetKeyValueA("ScalabilityGroups", "sg.AntiAliasingQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_AntiAliasingQuality = temp.ToString(); 

                _ = GetKeyValueA("ScalabilityGroups", "sg.ShadowQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_ShadowQuality = temp.ToString(); 

                _ = GetKeyValueA("ScalabilityGroups", "sg.PostProcessQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_PostProcessQuality = temp.ToString(); 

                _ = GetKeyValueA("ScalabilityGroups", "sg.TextureQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_TextureQuality = temp.ToString(); 

                _ = GetKeyValueA("ScalabilityGroups", "sg.EffectsQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_EffectsQuality = temp.ToString(); 

                _ = GetKeyValueA("ScalabilityGroups", "sg.FoliageQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_FoliageQuality = temp.ToString();

                _ = GetKeyValueA("ScalabilityGroups", "sg.ShadingQuality", string.Empty, temp, 255, GameUserSettingsLocation);
                R_EffectsQuality = temp.ToString();

                ApplyTrackBars();


            }
        }

        public void ApplyTrackBars()
        {
            ResolutionQuality.Value = Convert.ToInt32(R_ResolutionQuality);
        }
    }
}