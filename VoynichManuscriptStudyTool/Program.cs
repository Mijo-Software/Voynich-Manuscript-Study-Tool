using System;
using System.Windows.Forms;

namespace VoynichManuscriptStudyTool
{
	/// <summary>
	/// Program
	/// </summary>
	internal static class Program
	{
		/// <summary>
		/// maion entrance point of the application
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			using (MainForm mainForm = new MainForm())
			{
				Application.Run(mainForm: mainForm);
			}
		}
	}
}
