/********************************************************************/
/*  Office 2007 Renderer Project                                    */
/*                                                                  */
/*  Use the Office2007Renderer class as a custom renderer by        */
/*  providing it to the ToolStripManager.Renderer property. Then    */
/*  all tool strips, menu strips, status strips etc will be drawn   */
/*  using the Office 2007 style renderer in your application.       */
/*                                                                  */
/*   Author: Phil Wright                                            */
/*  Website: www.componentfactory.com                               */
/*  Contact: phil.wright@componentfactory.com                       */
/********************************************************************/

using System.Drawing;
using System.Windows.Forms;

namespace Office2007Rendering
{
	/// <summary>
	/// Provide Office 2007 Blue Theme colors
	/// </summary>
	public class Office2007ColorTable : ProfessionalColorTable
	{
		#region Static Fixed Colors - Blue Color Scheme
		private static readonly Color _contextMenuBack = Color.FromArgb(red: 250, green: 250, blue: 250);
		private static readonly Color _buttonPressedBegin = Color.FromArgb(red: 248, green: 181, blue: 106);
		private static readonly Color _buttonPressedEnd = Color.FromArgb(red: 255, green: 208, blue: 134);
		private static readonly Color _buttonPressedMiddle = Color.FromArgb(red: 251, green: 140, blue: 60);
		private static readonly Color _buttonSelectedBegin = Color.FromArgb(red: 255, green: 255, blue: 222);
		private static readonly Color _buttonSelectedEnd = Color.FromArgb(red: 255, green: 203, blue: 136);
		private static readonly Color _buttonSelectedMiddle = Color.FromArgb(red: 255, green: 225, blue: 172);
		private static readonly Color _menuItemSelectedBegin = Color.FromArgb(red: 255, green: 213, blue: 103);
		private static readonly Color _menuItemSelectedEnd = Color.FromArgb(red: 255, green: 228, blue: 145);
		private static readonly Color _checkBack = Color.FromArgb(red: 255, green: 227, blue: 149);
		private static readonly Color _gripDark = Color.FromArgb(red: 111, green: 157, blue: 217);
		private static readonly Color _gripLight = Color.FromArgb(red: 255, green: 255, blue: 255);
		private static readonly Color _imageMargin = Color.FromArgb(red: 233, green: 238, blue: 238);
		private static readonly Color _menuBorder = Color.FromArgb(red: 134, green: 134, blue: 134);
		private static readonly Color _overflowBegin = Color.FromArgb(red: 167, green: 204, blue: 251);
		private static readonly Color _overflowEnd = Color.FromArgb(red: 101, green: 147, blue: 207);
		private static readonly Color _overflowMiddle = Color.FromArgb(red: 167, green: 204, blue: 251);
		private static readonly Color _menuToolBack = Color.FromArgb(red: 191, green: 219, blue: 255);
		private static readonly Color _separatorDark = Color.FromArgb(red: 154, green: 198, blue: 255);
		private static readonly Color _separatorLight = Color.FromArgb(red: 255, green: 255, blue: 255);
		private static readonly Color _statusStripLight = Color.FromArgb(red: 215, green: 229, blue: 247);
		private static readonly Color _statusStripDark = Color.FromArgb(red: 172, green: 201, blue: 238);
		private static readonly Color _toolStripBorder = Color.FromArgb(red: 111, green: 157, blue: 217);
		private static readonly Color _toolStripContentEnd = Color.FromArgb(red: 164, green: 195, blue: 235);
		private static readonly Color _toolStripBegin = Color.FromArgb(red: 227, green: 239, blue: 255);
		private static readonly Color _toolStripEnd = Color.FromArgb(red: 152, green: 186, blue: 230);
		private static readonly Color _toolStripMiddle = Color.FromArgb(red: 222, green: 236, blue: 255);
		private static readonly Color _buttonBorder = Color.FromArgb(red: 121, green: 153, blue: 194);
		#endregion

		#region Identity
		/// <summary>
		/// Initialize a new instance of the Office2007ColorTable class.
		/// </summary>
		public Office2007ColorTable()
		{
		}
		#endregion

		#region ButtonPressed
		/// <summary>
		/// Gets the starting color of the gradient used when the button is pressed down.
		/// </summary>
		public override Color ButtonPressedGradientBegin
		{
			get { return _buttonPressedBegin; }
		}

		/// <summary>
		/// Gets the end color of the gradient used when the button is pressed down.
		/// </summary>
		public override Color ButtonPressedGradientEnd
		{
			get { return _buttonPressedEnd; }
		}

		/// <summary>
		/// Gets the middle color of the gradient used when the button is pressed down.
		/// </summary>
		public override Color ButtonPressedGradientMiddle
		{
			get { return _buttonPressedMiddle; }
		}
		#endregion

		#region ButtonSelected
		/// <summary>
		/// Gets the starting color of the gradient used when the button is selected.
		/// </summary>
		public override Color ButtonSelectedGradientBegin
		{
			get { return _buttonSelectedBegin; }
		}

		/// <summary>
		/// Gets the end color of the gradient used when the button is selected.
		/// </summary>
		public override Color ButtonSelectedGradientEnd
		{
			get { return _buttonSelectedEnd; }
		}

		/// <summary>
		/// Gets the middle color of the gradient used when the button is selected.
		/// </summary>
		public override Color ButtonSelectedGradientMiddle
		{
			get { return _buttonSelectedMiddle; }
		}

		/// <summary>
		/// Gets the border color to use with ButtonSelectedHighlight.
		/// </summary>
		public override Color ButtonSelectedHighlightBorder
		{
			get { return _buttonBorder; }
		}
		#endregion

		#region Check
		/// <summary>
		/// Gets the solid color to use when the check box is selected and gradients are being used.
		/// </summary>
		public override Color CheckBackground
		{
			get { return _checkBack; }
		}
		#endregion

		#region Grip
		/// <summary>
		/// Gets the color to use for shadow effects on the grip or move handle.
		/// </summary>
		public override Color GripDark
		{
			get { return _gripDark; }
		}

		/// <summary>
		/// Gets the color to use for highlight effects on the grip or move handle.
		/// </summary>
		public override Color GripLight
		{
			get { return _gripLight; }
		}
		#endregion

		#region ImageMargin
		/// <summary>
		/// Gets the starting color of the gradient used in the image margin of a ToolStripDropDownMenu.
		/// </summary>
		public override Color ImageMarginGradientBegin
		{
			get { return _imageMargin; }
		}
		#endregion

		#region MenuBorder
		/// <summary>
		/// Gets the border color or a MenuStrip.
		/// </summary>
		public override Color MenuBorder
		{
			get { return _menuBorder; }
		}
		#endregion

		#region MenuItem
		/// <summary>
		/// Gets the starting color of the gradient used when a top-level ToolStripMenuItem is pressed down.
		/// </summary>
		public override Color MenuItemPressedGradientBegin
		{
			get { return _toolStripBegin; }
		}

		/// <summary>
		/// Gets the end color of the gradient used when a top-level ToolStripMenuItem is pressed down.
		/// </summary>
		public override Color MenuItemPressedGradientEnd
		{
			get { return _toolStripEnd; }
		}

		/// <summary>
		/// Gets the middle color of the gradient used when a top-level ToolStripMenuItem is pressed down.
		/// </summary>
		public override Color MenuItemPressedGradientMiddle
		{
			get { return _toolStripMiddle; }
		}

		/// <summary>
		/// Gets the starting color of the gradient used when the ToolStripMenuItem is selected.
		/// </summary>
		public override Color MenuItemSelectedGradientBegin
		{
			get { return _menuItemSelectedBegin; }
		}

		/// <summary>
		/// Gets the end color of the gradient used when the ToolStripMenuItem is selected.
		/// </summary>
		public override Color MenuItemSelectedGradientEnd
		{
			get { return _menuItemSelectedEnd; }
		}
		#endregion

		#region MenuStrip
		/// <summary>
		/// Gets the starting color of the gradient used in the MenuStrip.
		/// </summary>
		public override Color MenuStripGradientBegin
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		/// Gets the end color of the gradient used in the MenuStrip.
		/// </summary>
		public override Color MenuStripGradientEnd
		{
			get { return _menuToolBack; }
		}
		#endregion

		#region OverflowButton
		/// <summary>
		/// Gets the starting color of the gradient used in the ToolStripOverflowButton.
		/// </summary>
		public override Color OverflowButtonGradientBegin
		{
			get { return _overflowBegin; }
		}

		/// <summary>
		/// Gets the end color of the gradient used in the ToolStripOverflowButton.
		/// </summary>
		public override Color OverflowButtonGradientEnd
		{
			get { return _overflowEnd; }
		}

		/// <summary>
		/// Gets the middle color of the gradient used in the ToolStripOverflowButton.
		/// </summary>
		public override Color OverflowButtonGradientMiddle
		{
			get { return _overflowMiddle; }
		}
		#endregion

		#region RaftingContainer
		/// <summary>
		/// Gets the starting color of the gradient used in the ToolStripContainer.
		/// </summary>
		public override Color RaftingContainerGradientBegin
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		/// Gets the end color of the gradient used in the ToolStripContainer.
		/// </summary>
		public override Color RaftingContainerGradientEnd
		{
			get { return _menuToolBack; }
		}
		#endregion

		#region Separator
		/// <summary>
		/// Gets the color to use to for shadow effects on the ToolStripSeparator.
		/// </summary>
		public override Color SeparatorDark
		{
			get { return _separatorDark; }
		}

		/// <summary>
		/// Gets the color to use to for highlight effects on the ToolStripSeparator.
		/// </summary>
		public override Color SeparatorLight
		{
			get { return _separatorLight; }
		}
		#endregion

		#region StatusStrip
		/// <summary>
		/// Gets the starting color of the gradient used on the StatusStrip.
		/// </summary>
		public override Color StatusStripGradientBegin
		{
			get { return _statusStripLight; }
		}

		/// <summary>
		/// Gets the end color of the gradient used on the StatusStrip.
		/// </summary>
		public override Color StatusStripGradientEnd
		{
			get { return _statusStripDark; }
		}
		#endregion

		#region ToolStrip
		/// <summary>
		/// Gets the border color to use on the bottom edge of the ToolStrip.
		/// </summary>
		public override Color ToolStripBorder
		{
			get { return _toolStripBorder; }
		}

		/// <summary>
		/// Gets the starting color of the gradient used in the ToolStripContentPanel.
		/// </summary>
		public override Color ToolStripContentPanelGradientBegin
		{
			get { return _toolStripContentEnd; }
		}

		/// <summary>
		/// Gets the end color of the gradient used in the ToolStripContentPanel.
		/// </summary>
		public override Color ToolStripContentPanelGradientEnd
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		/// Gets the solid background color of the ToolStripDropDown.
		/// </summary>
		public override Color ToolStripDropDownBackground
		{
			get { return _contextMenuBack; }
		}

		/// <summary>
		/// Gets the starting color of the gradient used in the ToolStrip background.
		/// </summary>
		public override Color ToolStripGradientBegin
		{
			get { return _toolStripBegin; }
		}

		/// <summary>
		/// Gets the end color of the gradient used in the ToolStrip background.
		/// </summary>
		public override Color ToolStripGradientEnd
		{
			get { return _toolStripEnd; }
		}

		/// <summary>
		/// Gets the middle color of the gradient used in the ToolStrip background.
		/// </summary>
		public override Color ToolStripGradientMiddle
		{
			get { return _toolStripMiddle; }
		}

		/// <summary>
		/// Gets the starting color of the gradient used in the ToolStripPanel.
		/// </summary>
		public override Color ToolStripPanelGradientBegin
		{
			get { return _menuToolBack; }
		}

		/// <summary>
		/// Gets the end color of the gradient used in the ToolStripPanel.
		/// </summary>
		public override Color ToolStripPanelGradientEnd
		{
			get { return _menuToolBack; }
		}
		#endregion
	}
}
