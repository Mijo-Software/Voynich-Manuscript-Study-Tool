using System;
using System.Windows.Forms;
using Office2007Rendering;
using VoynichManuscriptStudyTool.Properties;

namespace VoynichManuscriptStudyTool
{
	/// <summary>
	/// MainForm : Form
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public MainForm() => InitializeComponent();

		private void AdjustViewsFromToolbar()
		{
			toolStripMenuItemView1.Checked = toolStripButtonView1.Checked;
			toolStripMenuItemView2.Checked = toolStripButtonView2.Checked;
			toolStripMenuItemView3.Checked = toolStripButtonView3.Checked;
		}

		private void AdjustViewsFromMenuItem()
		{
			toolStripButtonView1.Checked = toolStripMenuItemView1.Checked;
			toolStripButtonView2.Checked = toolStripMenuItemView2.Checked;
			toolStripButtonView3.Checked = toolStripMenuItemView3.Checked;
		}

		/// <summary>
		/// Load the main window
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">event arguments</param>
		/// <remarks>The parameters <paramref name="e"/> and <paramref name="sender"/> are not needed, but must be indicated.</remarks>
		private void MainForm_Load(object sender, EventArgs e)
		{
			ToolStripManager.Renderer = new Office2007Renderer();
			toolStripButtonViewFirstPage.Visible = false;
			toolStripButtonViewPreviousPage.Visible = false;
			toolStripButtonViewNextPage.Visible = false;
			toolStripButtonViewLastPage.Visible = false;
			toolStripSeparatorAfterViewPage.Visible = false;
			AdjustViewsFromToolbar();
		}

		private void PageToBegin(object sender, EventArgs e)
		{
		}

		private void PageToNext(object sender, EventArgs e)
		{
		}

		private void PageToPrevious(object sender, EventArgs e)
		{
		}

		private void PageToEnd(object sender, EventArgs e)
		{
		}

		private void ToogleView1(object sender, EventArgs e)
		{

		}

		private void ToogleView2(object sender, EventArgs e)
		{

		}

		private void ToogleView3(object sender, EventArgs e)
		{

		}

		private void ToolStripLabelView_Click(object sender, EventArgs e)
		{
			toolStripButtonView1.Checked = true;
			toolStripButtonView2.Checked = true;
			toolStripButtonView3.Checked = true;
			splitContainerMain.Panel1Collapsed = !toolStripButtonView1.Checked;
			splitContainerView.Panel1Collapsed = !toolStripButtonView2.Checked;
			splitContainerView.Panel2Collapsed = !toolStripButtonView3.Checked;
		}

		private void ZoomIn(object sender, EventArgs e)
		{
		}

		private void ZoomOut(object sender, EventArgs e)
		{
		}

		private void ToolStripButtonView1_Click(object sender, EventArgs e)
		{
			ToogleView1(sender: sender, e: e);
			//AdjustViewsFromToolbar();
		}

		private void ToolStripButtonView2_Click(object sender, EventArgs e)
		{
			ToogleView2(sender: sender, e: e);
			//AdjustViewsFromToolbar();
		}

		private void ToolStripButtonView3_Click(object sender, EventArgs e)
		{
			ToogleView1(sender: sender, e: e);
			//AdjustViewsFromToolbar();
		}

		private void ToolStripMenuItemView1_Click(object sender, EventArgs e)
		{
			ToogleView1(sender: sender, e: e);
			//AdjustViewsFromMenuItem();
		}

		private void ToolStripMenuItemView2_Click(object sender, EventArgs e)
		{
			ToogleView2(sender: sender, e: e);
			//AdjustViewsFromMenuItem();
		}

		private void ToolStripMenuItemView3_Click(object sender, EventArgs e)
		{
			ToogleView3(sender: sender, e: e);
			//AdjustViewsFromMenuItem();
		}

		private void ToolStripMenuItemExit_Click(object sender, EventArgs e) => Close();

		private void ToolStripButtonExit_Click(object sender, EventArgs e) => Close();

		private void SetThemeSystem(object sender, EventArgs e)
		{
			toolStripMenuItemThemeSystem.Checked = true;
			toolStripMenuItemThemeProfessional.Checked = false;
			toolStripMenuItemThemeOffice2007Blue.Checked = false;
			ToolStripManager.Renderer = new ToolStripSystemRenderer();
		}

		private void SetThemeProfessional(object sender, EventArgs e)
		{
			toolStripMenuItemThemeSystem.Checked = false;
			toolStripMenuItemThemeProfessional.Checked = true;
			toolStripMenuItemThemeOffice2007Blue.Checked = false;
			ToolStripManager.Renderer = new ToolStripProfessionalRenderer();
		}

		private void SetThemeOffice2007Blue(object sender, EventArgs e)
		{
			toolStripMenuItemThemeSystem.Checked = false;
			toolStripMenuItemThemeProfessional.Checked = false;
			toolStripMenuItemThemeOffice2007Blue.Checked = true;
			ToolStripManager.Renderer = new Office2007Renderer();
		}

		private void SetIconsetFatcow(object sender, EventArgs e)
		{
			toolStripMenuItemIconsetFatcow.Checked = true;
			toolStripMenuItemIconsetFugue.Checked = false;
			toolStripMenuItemExit.Image = Resources.fatcow_door_in_16;
			toolStripMenuItemFirstPage.Image = Resources.fatcow_document_page_16;
			toolStripMenuItemPreviousPage.Image = Resources.fatcow_document_page_previous_16;
			toolStripMenuItemNextPage.Image = Resources.fatcow_document_page_next_16;
			toolStripMenuItemLastPage.Image = Resources.fatcow_document_page_last_16;
			toolStripMenuItemThemes.Image = Resources.fatcow_palette_16;
			toolStripMenuItemIconsets.Image = Resources.fatcow_categories_16;
			toolStripMenuItemSaveConfiguration.Image = Resources.fatcow_disk_16;
			toolStripMenuItemZoomIn.Image = Resources.fatcow_magnifier_zoom_in_16;
			toolStripMenuItemZoomOut.Image = Resources.fatcow_magnifier_zoom_out_16;
			toolStripButtonExit.Image = toolStripMenuItemExit.Image;
			toolStripButtonFirstPage.Image = toolStripMenuItemFirstPage.Image;
			toolStripButtonPreviousPage.Image = toolStripMenuItemPreviousPage.Image;
			toolStripButtonNextPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonLastPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonViewFirstPage.Image = toolStripMenuItemFirstPage.Image;
			toolStripButtonViewPreviousPage.Image = toolStripMenuItemPreviousPage.Image;
			toolStripButtonViewNextPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonViewLastPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonZoomIn.Image = toolStripMenuItemZoomIn.Image;
			toolStripButtonZoomOut.Image = toolStripMenuItemZoomOut.Image;
		}

		private void SetIconsetFugue(object sender, EventArgs e)
		{
			toolStripMenuItemIconsetFatcow.Checked = false;
			toolStripMenuItemIconsetFugue.Checked = true;
			toolStripMenuItemExit.Image = Resources.fugue_door_in_16;
			toolStripMenuItemFirstPage.Image = Resources.fugue_document_page_16;
			toolStripMenuItemPreviousPage.Image = Resources.fugue_document_page_previous_16;
			toolStripMenuItemNextPage.Image = Resources.fugue_document_page_next_16;
			toolStripMenuItemLastPage.Image = Resources.fugue_document_page_last_16;
			toolStripMenuItemThemes.Image = Resources.fugue_palette_16;
			toolStripMenuItemIconsets.Image = Resources.fugue_categories_16;
			toolStripMenuItemSaveConfiguration.Image = Resources.fugue_disk_16;
			toolStripMenuItemZoomIn.Image = Resources.fugue_magnifier_zoom_in_16;
			toolStripMenuItemZoomOut.Image = Resources.fugue_magnifier_zoom_out_16;
			toolStripButtonExit.Image = toolStripMenuItemExit.Image;
			toolStripButtonFirstPage.Image = toolStripMenuItemFirstPage.Image;
			toolStripButtonPreviousPage.Image = toolStripMenuItemPreviousPage.Image;
			toolStripButtonNextPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonLastPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonViewFirstPage.Image = toolStripMenuItemFirstPage.Image;
			toolStripButtonViewPreviousPage.Image = toolStripMenuItemPreviousPage.Image;
			toolStripButtonViewNextPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonViewLastPage.Image = toolStripMenuItemNextPage.Image;
			toolStripButtonZoomIn.Image = toolStripMenuItemZoomIn.Image;
			toolStripButtonZoomOut.Image = toolStripMenuItemZoomOut.Image;
		}

		private void ToolStripMenuItemSaveConfiguration_Click(object sender, EventArgs e)
		{
		}
	}
}
