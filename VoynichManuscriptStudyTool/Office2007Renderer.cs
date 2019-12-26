// Must call base class, otherwise the subsequent drawing does not appear!
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

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Office2007Rendering
{
	/// <summary>
	/// Draw ToolStrips using the Office 2007 themed appearance.
	/// </summary>
	public class Office2007Renderer : ToolStripProfessionalRenderer
	{
		#region GradientItemColors
		/// <summary>
		/// 
		/// </summary>
		private class GradientItemColors
		{
			#region Public Fields
			/// <summary>
			/// 
			/// </summary>
			public Color InsideTop1;
			/// <summary>
			/// 
			/// </summary>
			public Color InsideTop2;
			/// <summary>
			/// 
			/// </summary>
			public Color InsideBottom1;
			/// <summary>
			/// 
			/// </summary>
			public Color InsideBottom2;
			/// <summary>
			/// 
			/// </summary>
			public Color FillTop1;
			/// <summary>
			/// 
			/// </summary>
			public Color FillTop2;
			/// <summary>
			/// 
			/// </summary>
			public Color FillBottom1;
			/// <summary>
			/// 
			/// </summary>
			public Color FillBottom2;
			/// <summary>
			/// 
			/// </summary>
			public Color Border1;
			/// <summary>
			/// 
			/// </summary>
			public Color Border2;
			#endregion

			#region Identity
			/// <summary>
			/// 
			/// </summary>
			/// <param name="insideTop1"></param>
			/// <param name="insideTop2"></param>
			/// <param name="insideBottom1"></param>
			/// <param name="insideBottom2"></param>
			/// <param name="fillTop1"></param>
			/// <param name="fillTop2"></param>
			/// <param name="fillBottom1"></param>
			/// <param name="fillBottom2"></param>
			/// <param name="border1"></param>
			/// <param name="border2"></param>
			public GradientItemColors(Color insideTop1, Color insideTop2,
																Color insideBottom1, Color insideBottom2,
																Color fillTop1, Color fillTop2,
																Color fillBottom1, Color fillBottom2,
																Color border1, Color border2)
			{
				InsideTop1 = insideTop1;
				InsideTop2 = insideTop2;
				InsideBottom1 = insideBottom1;
				InsideBottom2 = insideBottom2;
				FillTop1 = fillTop1;
				FillTop2 = fillTop2;
				FillBottom1 = fillBottom1;
				FillBottom2 = fillBottom2;
				Border1 = border1;
				Border2 = border2;
			}
			#endregion
		}
		#endregion

		#region Static Metrics
		private static readonly int _gripOffset = 1;
		private static readonly int _gripSquare = 2;
		private static readonly int _gripSize = 3;
		private static readonly int _gripMove = 4;
		private static readonly int _gripLines = 3;
		private static readonly int _checkInset = 1;
		private static readonly int _marginInset = 2;
		private static readonly int _separatorInset = 31;
		private static readonly float _cutToolItemMenu = 1.0f;
		private static readonly float _cutContextMenu = 0f;
		private static readonly float _cutMenuItemBack = 1.2f;
		private static readonly float _contextCheckTickThickness = 1.6f;
		private static readonly Blend _statusStripBlend;
		#endregion

		#region Static Colors
		private static readonly Color _c1 = Color.FromArgb(red: 167, green: 167, blue: 167);
		private static readonly Color _c2 = Color.FromArgb(red: 21, green: 66, blue: 139);
		private static readonly Color _c3 = Color.FromArgb(red: 76, green: 83, blue: 92);
		private static readonly Color _c4 = Color.FromArgb(red: 250, green: 250, blue: 250);
		private static readonly Color _c5 = Color.FromArgb(red: 248, green: 248, blue: 248);
		private static readonly Color _c6 = Color.FromArgb(red: 243, green: 243, blue: 243);
		private static readonly Color _r1 = Color.FromArgb(red: 255, green: 255, blue: 251);
		private static readonly Color _r2 = Color.FromArgb(red: 255, green: 249, blue: 227);
		private static readonly Color _r3 = Color.FromArgb(red: 255, green: 242, blue: 201);
		private static readonly Color _r4 = Color.FromArgb(red: 255, green: 248, blue: 181);
		private static readonly Color _r5 = Color.FromArgb(red: 255, green: 252, blue: 229);
		private static readonly Color _r6 = Color.FromArgb(red: 255, green: 235, blue: 166);
		private static readonly Color _r7 = Color.FromArgb(red: 255, green: 213, blue: 103);
		private static readonly Color _r8 = Color.FromArgb(red: 255, green: 228, blue: 145);
		private static readonly Color _r9 = Color.FromArgb(red: 160, green: 188, blue: 228);
		private static readonly Color _rA = Color.FromArgb(red: 121, green: 153, blue: 194);
		private static readonly Color _rB = Color.FromArgb(red: 182, green: 190, blue: 192);
		private static readonly Color _rC = Color.FromArgb(red: 155, green: 163, blue: 167);
		private static readonly Color _rD = Color.FromArgb(red: 233, green: 168, blue: 97);
		private static readonly Color _rE = Color.FromArgb(red: 247, green: 164, blue: 39);
		private static readonly Color _rF = Color.FromArgb(red: 246, green: 156, blue: 24);
		private static readonly Color _rG = Color.FromArgb(red: 253, green: 173, blue: 17);
		private static readonly Color _rH = Color.FromArgb(red: 254, green: 185, blue: 108);
		private static readonly Color _rI = Color.FromArgb(red: 253, green: 164, blue: 97);
		private static readonly Color _rJ = Color.FromArgb(red: 252, green: 143, blue: 61);
		private static readonly Color _rK = Color.FromArgb(red: 255, green: 208, blue: 134);
		private static readonly Color _rL = Color.FromArgb(red: 249, green: 192, blue: 103);
		private static readonly Color _rM = Color.FromArgb(red: 250, green: 195, blue: 93);
		private static readonly Color _rN = Color.FromArgb(red: 248, green: 190, blue: 81);
		private static readonly Color _rO = Color.FromArgb(red: 255, green: 208, blue: 49);
		private static readonly Color _rP = Color.FromArgb(red: 254, green: 214, blue: 168);
		private static readonly Color _rQ = Color.FromArgb(red: 252, green: 180, blue: 100);
		private static readonly Color _rR = Color.FromArgb(red: 252, green: 161, blue: 54);
		private static readonly Color _rS = Color.FromArgb(red: 254, green: 238, blue: 170);
		private static readonly Color _rT = Color.FromArgb(red: 249, green: 202, blue: 113);
		private static readonly Color _rU = Color.FromArgb(red: 250, green: 205, blue: 103);
		private static readonly Color _rV = Color.FromArgb(red: 248, green: 200, blue: 91);
		private static readonly Color _rW = Color.FromArgb(red: 255, green: 218, blue: 59);
		private static readonly Color _rX = Color.FromArgb(red: 254, green: 185, blue: 108);
		private static readonly Color _rY = Color.FromArgb(red: 252, green: 161, blue: 54);
		private static readonly Color _rZ = Color.FromArgb(red: 254, green: 238, blue: 170);

		// Color scheme values
		private static readonly Color _textDisabled = _c1;
		private static readonly Color _textMenuStripItem = _c2;
		private static readonly Color _textStatusStripItem = _c2;
		private static readonly Color _textContextMenuItem = _c2;
		private static readonly Color _arrowDisabled = _c1;
		private static readonly Color _arrowLight = Color.FromArgb(red: 106, green: 126, blue: 197);
		private static readonly Color _arrowDark = Color.FromArgb(red: 64, green: 70, blue: 90);
		private static readonly Color _separatorMenuLight = Color.FromArgb(red: 245, green: 245, blue: 245);
		private static readonly Color _separatorMenuDark = Color.FromArgb(red: 197, green: 197, blue: 197);
		private static readonly Color _contextMenuBack = _c4;
		private static readonly Color _contextCheckBorder = Color.FromArgb(red: 242, green: 149, blue: 54);
		private static readonly Color _contextCheckTick = Color.FromArgb(red: 66, green: 75, blue: 138);
		private static readonly Color _statusStripBorderDark = Color.FromArgb(red: 86, green: 125, blue: 176);
		private static readonly Color _statusStripBorderLight = Color.White;
		private static readonly Color _gripDark = Color.FromArgb(red: 114, green: 152, blue: 204);
		private static readonly Color _gripLight = _c5;
		private static readonly GradientItemColors _itemContextItemEnabledColors = new GradientItemColors(insideTop1: _r1, insideTop2: _r2, insideBottom1: _r3, insideBottom2: _r4, fillTop1: _r5, fillTop2: _r6, fillBottom1: _r7, fillBottom2: _r8, border1: Color.FromArgb(red: 217, green: 203, blue: 150), border2: Color.FromArgb(red: 192, green: 167, blue: 118));
		private static readonly GradientItemColors _itemDisabledColors = new GradientItemColors(insideTop1: _c4, insideTop2: _c6, insideBottom1: Color.FromArgb(red: 236, green: 236, blue: 236), insideBottom2: Color.FromArgb(red: 230, green: 230, blue: 230), fillTop1: _c6, fillTop2: Color.FromArgb(red: 224, green: 224, blue: 224), fillBottom1: Color.FromArgb(red: 200, green: 200, blue: 200), fillBottom2: Color.FromArgb(red: 210, green: 210, blue: 210), border1: Color.FromArgb(red: 212, green: 212, blue: 212), border2: Color.FromArgb(red: 195, green: 195, blue: 195));
		private static readonly GradientItemColors _itemToolItemSelectedColors = new GradientItemColors(insideTop1: _r1, insideTop2: _r2, insideBottom1: _r3, insideBottom2: _r4, fillTop1: _r5, fillTop2: _r6, fillBottom1: _r7, fillBottom2: _r8, border1: _r9, border2: _rA);
		private static readonly GradientItemColors _itemToolItemPressedColors = new GradientItemColors(insideTop1: _rD, insideTop2: _rE, insideBottom1: _rF, insideBottom2: _rG, fillTop1: _rH, fillTop2: _rI, fillBottom1: _rJ, fillBottom2: _rK, border1: _r9, border2: _rA);
		private static readonly GradientItemColors _itemToolItemCheckedColors = new GradientItemColors(insideTop1: _rL, insideTop2: _rM, insideBottom1: _rN, insideBottom2: _rO, fillTop1: _rP, fillTop2: _rQ, fillBottom1: _rR, fillBottom2: _rS, border1: _r9, border2: _rA);
		private static readonly GradientItemColors _itemToolItemCheckPressColors = new GradientItemColors(insideTop1: _rT, insideTop2: _rU, insideBottom1: _rV, insideBottom2: _rW, fillTop1: _rX, fillTop2: _rI, fillBottom1: _rY, fillBottom2: _rZ, border1: _r9, border2: _rA);
		#endregion

		#region Identity
		/// <summary>
		/// 
		/// </summary>
		static Office2007Renderer()
		{
			// One time creation of the blend for the status strip gradient brush
			_statusStripBlend = new Blend
			{
				Positions = new float[] { 0.0f, 0.25f, 0.25f, 0.57f, 0.86f, 1.0f },
				Factors = new float[] { 0.1f, 0.6f, 1.0f, 0.4f, 0.0f, 0.95f }
			};
		}

		/// <summary>
		/// Initialize a new instance of the Office2007Renderer class.
		/// </summary>
		public Office2007Renderer() : base(professionalColorTable: new Office2007ColorTable())
		{
		}
		#endregion

		#region OnRenderArrow
		/// <summary>
		/// Raises the RenderArrow event. 
		/// </summary>
		/// <param name="e">An ToolStripArrowRenderEventArgs containing the event data.</param>
		protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
		{
			// Cannot paint a zero sized area
			if ((e.ArrowRectangle.Width > 0) && (e.ArrowRectangle.Height > 0))
			{
				// Create a path that is used to fill the arrow
				using (GraphicsPath arrowPath = CreateArrowPath(item: e.Item, rect: e.ArrowRectangle, direction: e.Direction))
				{
					// Get the rectangle that encloses the arrow and expand slightly
					// so that the gradient is always within the expanding bounds
					RectangleF boundsF = arrowPath.GetBounds();
					boundsF.Inflate(x: 1f, y: 1f);
					Color color1 = (e.Item.Enabled ? _arrowLight : _arrowDisabled);
					Color color2 = (e.Item.Enabled ? _arrowDark : _arrowDisabled);
					float angle = 0;

					// Use gradient angle to match the arrow direction
					switch (e.Direction)
					{
						case ArrowDirection.Right:
							angle = 0;
							break;
						case ArrowDirection.Left:
							angle = 180f;
							break;
						case ArrowDirection.Down:
							angle = 90f;
							break;
						case ArrowDirection.Up:
							angle = 270f;
							break;
					}

					// Draw the actual arrow using a gradient
					using (LinearGradientBrush arrowBrush = new LinearGradientBrush(rect: boundsF, color1: color1, color2: color2, angle: angle))
					{
						e.Graphics.FillPath(brush: arrowBrush, path: arrowPath);
					}
				}
			}
		}
		#endregion

		#region OnRenderButtonBackground
		/// <summary>
		/// Raises the RenderButtonBackground event. 
		/// </summary>
		/// <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
		protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
		{
			// Cast to correct type
			ToolStripButton button = (ToolStripButton)e.Item;
			if (button.Selected || button.Pressed || button.Checked)
			{
				RenderToolButtonBackground(g: e.Graphics, button: button, toolstrip: e.ToolStrip);
			}
		}
		#endregion

		#region OnRenderDropDownButtonBackground
		/// <summary>
		/// Raises the RenderDropDownButtonBackground event. 
		/// </summary>
		/// <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
		protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Selected || e.Item.Pressed)
			{
				RenderToolDropButtonBackground(g: e.Graphics, item: e.Item, toolstrip: e.ToolStrip);
			}
		}
		#endregion

		#region OnRenderItemCheck
		/// <summary>
		/// Raises the RenderItemCheck event. 
		/// </summary>
		/// <param name="e">An ToolStripItemImageRenderEventArgs containing the event data.</param>
		protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
		{
			// Staring size of the checkbox is the image rectangle
			Rectangle checkBox = e.ImageRectangle;

			// Make the border of the check box 1 pixel bigger on all sides, as a minimum
			checkBox.Inflate(width: 1, height: 1);

			// Can we extend upwards?
			if (checkBox.Top > _checkInset)
			{
				int diff = checkBox.Top - _checkInset;
				checkBox.Y -= diff;
				checkBox.Height += diff;
			}

			// Can we extend downwards?
			if (checkBox.Height <= (e.Item.Bounds.Height - (_checkInset * 2)))
			{
				int diff = e.Item.Bounds.Height - (_checkInset * 2) - checkBox.Height;
				checkBox.Height += diff;
			}

			// Drawing with anti aliasing to create smoother appearance
			using (UseAntiAlias uaa = new UseAntiAlias(g: e.Graphics))
			{
				// Create border path for the check box
				using (GraphicsPath borderPath = CreateBorderPath(rect: checkBox, cut: _cutMenuItemBack))
				{
					// Fill the background in a solid color
					using (SolidBrush fillBrush = new SolidBrush(color: ColorTable.CheckBackground))
					{
						e.Graphics.FillPath(fillBrush, borderPath);
					}

					// Draw the border around the check box
					using (Pen borderPen = new Pen(color: _contextCheckBorder))
					{
						e.Graphics.DrawPath(borderPen, borderPath);
					}

					// If there is not an image, then we can draw the tick, square etc...
					if (e.Image != null)
					{
						CheckState checkState = CheckState.Unchecked;

						// Extract the check state from the item
						if (e.Item is ToolStripMenuItem item) // old if (e.Item is ToolStripMenuItem)
						{
							//old: ToolStripMenuItem item = (ToolStripMenuItem)e.Item;
							checkState = item.CheckState;
						}

						// Decide what graphic to draw
						switch (checkState)
						{
							case CheckState.Checked:
								// Create a path for the tick
								using (GraphicsPath tickPath = CreateTickPath(rect: checkBox))
								{
									// Draw the tick with a thickish brush
									using (Pen tickPen = new Pen(color: _contextCheckTick, width: _contextCheckTickThickness))
									{
										e.Graphics.DrawPath(tickPen, tickPath);
									}
								}
								break;
							case CheckState.Indeterminate:
								// Create a path for the indeterminate diamond
								using (GraphicsPath tickPath = CreateIndeterminatePath(rect: checkBox))
								{
									// Draw the tick with a thickish brush
									using (SolidBrush tickBrush = new SolidBrush(color: _contextCheckTick))
									{
										e.Graphics.FillPath(brush: tickBrush, path: tickPath);
									}
								}
								break;
						}
					}
				}
			}
		}
		#endregion

		#region OnRenderItemText
		/// <summary>
		/// Raises the RenderItemText event. 
		/// </summary>
		/// <param name="e">An ToolStripItemTextRenderEventArgs containing the event data.</param>
		protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
		{
			if ((e.ToolStrip is MenuStrip) ||
					(e.ToolStrip is ToolStrip) ||
					(e.ToolStrip is ContextMenuStrip) ||
					(e.ToolStrip is ToolStripDropDownMenu))
			{
				// We set the color depending on the enabled state
				if (!e.Item.Enabled)
				{
					e.TextColor = _textDisabled;
				}
				else
				{
					if ((e.ToolStrip is MenuStrip) && !e.Item.Pressed && !e.Item.Selected)
					{
						e.TextColor = _textMenuStripItem;
					}
					else if ((e.ToolStrip is StatusStrip) && !e.Item.Pressed && !e.Item.Selected)
					{
						e.TextColor = _textStatusStripItem;
					}
					else
					{
						e.TextColor = _textContextMenuItem;
					}
				}

				// All text is draw using the ClearTypeGridFit text rendering hint
				using (UseClearTypeGridFit clearTypeGridFit = new UseClearTypeGridFit(g: e.Graphics))
				{
					base.OnRenderItemText(e);
				}
			}
			else
			{
				base.OnRenderItemText(e);
			}
		}
		#endregion

		#region OnRenderItemImage
		/// <summary>
		/// Raises the RenderItemImage event. 
		/// </summary>
		/// <param name="e">An ToolStripItemImageRenderEventArgs containing the event data.</param>
		protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
		{
			// We only override the image drawing for context menus
			if ((e.ToolStrip is ContextMenuStrip) ||
					(e.ToolStrip is ToolStripDropDownMenu))
			{
				if (e.Image != null)
				{
					if (e.Item.Enabled)
					{
						e.Graphics.DrawImage(e.Image, e.ImageRectangle);
					}
					else
					{
						ControlPaint.DrawImageDisabled(graphics: e.Graphics, image: e.Image, x: e.ImageRectangle.X, y: e.ImageRectangle.Y, background: Color.Transparent);
					}
				}
			}
			else
			{
				base.OnRenderItemImage(e);
			}
		}
		#endregion

		#region OnRenderMenuItemBackground
		/// <summary>
		/// Raises the RenderMenuItemBackground event. 
		/// </summary>
		/// <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
		protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
		{
			if ((e.ToolStrip is MenuStrip) ||
					(e.ToolStrip is ContextMenuStrip) ||
					(e.ToolStrip is ToolStripDropDownMenu))
			{
				if ((e.Item.Pressed) && (e.ToolStrip is MenuStrip))
				{
					// Draw the menu/tool strip as a header for a context menu item
					DrawContextMenuHeader(g: e.Graphics, item: e.Item);
				}
				else
				{
					// We only draw a background if the item is selected and enabled
					if (e.Item.Selected)
					{
						if (e.Item.Enabled)
						{
							// Do we draw as a menu strip or context menu item?
							if (e.ToolStrip is MenuStrip)
							{
								DrawGradientToolItem(g: e.Graphics, item: e.Item, colors: _itemToolItemSelectedColors);
							}
							else
							{
								DrawGradientContextMenuItem(g: e.Graphics, item: e.Item, colors: _itemContextItemEnabledColors);
							}
						}
						else
						{
							// Get the mouse position in tool strip coordinates
							Point mousePos = e.ToolStrip.PointToClient(p: Control.MousePosition);

							// If the mouse is not in the item area, then draw disabled
							if (!e.Item.Bounds.Contains(pt: mousePos))
							{
								// Do we draw as a menu strip or context menu item?
								if (e.ToolStrip is MenuStrip)
								{
									DrawGradientToolItem(g: e.Graphics, item: e.Item, colors: _itemDisabledColors);
								}
								else
								{
									DrawGradientContextMenuItem(g: e.Graphics, item: e.Item, colors: _itemDisabledColors);
								}
							}
						}
					}
				}
			}
			else
			{
				base.OnRenderMenuItemBackground(e);
			}
		}
		#endregion

		#region OnRenderSplitButtonBackground
		/// <summary>
		/// Raises the RenderSplitButtonBackground event. 
		/// </summary>
		/// <param name="e">An ToolStripItemRenderEventArgs containing the event data.</param>
		protected override void OnRenderSplitButtonBackground(ToolStripItemRenderEventArgs e)
		{
			if (e.Item.Selected || e.Item.Pressed)
			{
				// Cast to correct type
				ToolStripSplitButton splitButton = (ToolStripSplitButton)e.Item;

				// Draw the border and background
				RenderToolSplitButtonBackground(g: e.Graphics, splitButton: splitButton, toolstrip: e.ToolStrip);

				// Get the rectangle that needs to show the arrow
				Rectangle arrowBounds = splitButton.DropDownButtonBounds;

				// Draw the arrow on top of the background
				OnRenderArrow(new ToolStripArrowRenderEventArgs(g: e.Graphics,
																												toolStripItem: splitButton,
																												arrowRectangle: arrowBounds,
																												arrowColor: SystemColors.ControlText,
																												arrowDirection: ArrowDirection.Down));
			}
			else
			{
				base.OnRenderSplitButtonBackground(e);
			}
		}
		#endregion

		#region OnRenderStatusStripSizingGrip
		/// <summary>
		/// Raises the RenderStatusStripSizingGrip event. 
		/// </summary>
		/// <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
		protected override void OnRenderStatusStripSizingGrip(ToolStripRenderEventArgs e)
		{
			using (SolidBrush darkBrush = new SolidBrush(_gripDark),
											lightBrush = new SolidBrush(_gripLight))
			{
				// Do we need to invert the drawing edge?
				bool rtl = (e.ToolStrip.RightToLeft == RightToLeft.Yes);

				// Find vertical position of the lowest grip line
				int y = e.AffectedBounds.Bottom - _gripSize * 2 + 1;

				// Draw three lines of grips
				for (int i = _gripLines; i >= 1; i--)
				{
					// Find the rightmost grip position on the line
					int x = (rtl ? e.AffectedBounds.Left + 1 :
												 e.AffectedBounds.Right - _gripSize * 2 + 1);

					// Draw grips from right to left on line
					for (int j = 0; j < i; j++)
					{
						// Just the single grip glyph
						DrawGripGlyph(g: e.Graphics, x: x, y: y, darkBrush: darkBrush, lightBrush: lightBrush);

						// Move left to next grip position
						x -= (rtl ? -_gripMove : _gripMove);
					}

					// Move upwards to next grip line
					y -= _gripMove;
				}
			}
		}
		#endregion

		#region OnRenderToolStripContentPanelBackground
		/// <summary>
		/// Raises the RenderToolStripContentPanelBackground event. 
		/// </summary>
		/// <param name="e">An ToolStripContentPanelRenderEventArgs containing the event data.</param>
		protected override void OnRenderToolStripContentPanelBackground(ToolStripContentPanelRenderEventArgs e)
		{
			// Must call base class, otherwise the subsequent drawing does not appear!
			base.OnRenderToolStripContentPanelBackground(e);

			// Cannot paint a zero sized area
			if ((e.ToolStripContentPanel.Width > 0) &&
					(e.ToolStripContentPanel.Height > 0))
			{
				using (LinearGradientBrush backBrush = new LinearGradientBrush(rect: e.ToolStripContentPanel.ClientRectangle,
																																			 color1: ColorTable.ToolStripContentPanelGradientEnd,
																																			 color2: ColorTable.ToolStripContentPanelGradientBegin,
																																			 angle: 90f))
				{
					e.Graphics.FillRectangle(brush: backBrush, rect: e.ToolStripContentPanel.ClientRectangle);
				}
			}
		}
		#endregion

		#region OnRenderSeparator
		/// <summary>
		/// Raises the RenderSeparator event. 
		/// </summary>
		/// <param name="e">An ToolStripSeparatorRenderEventArgs containing the event data.</param>
		protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
		{
			if ((e.ToolStrip is ContextMenuStrip) ||
					(e.ToolStrip is ToolStripDropDownMenu))
			{
				// Create the light and dark line pens
				using (Pen lightPen = new Pen(_separatorMenuLight),
										darkPen = new Pen(_separatorMenuDark))
				{
					DrawSeparator(g: e.Graphics, vertical: e.Vertical, rect: e.Item.Bounds,
												lightPen: lightPen, darkPen: darkPen, horizontalInset: _separatorInset,
												rtl: (e.ToolStrip.RightToLeft == RightToLeft.Yes));
				}
			}
			else if (e.ToolStrip is StatusStrip)
			{
				// Create the light and dark line pens
				using (Pen lightPen = new Pen(color: ColorTable.SeparatorLight),
										darkPen = new Pen(color: ColorTable.SeparatorDark))
				{
					DrawSeparator(g: e.Graphics, vertical: e.Vertical, rect: e.Item.Bounds,
												lightPen: lightPen, darkPen: darkPen, horizontalInset: 0, rtl: false);
				}
			}
			else
			{
				base.OnRenderSeparator(e);
			}
		}
		#endregion

		#region OnRenderToolStripBackground
		/// <summary>
		/// Raises the RenderToolStripBackground event. 
		/// </summary>
		/// <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
		protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
		{
			if ((e.ToolStrip is ContextMenuStrip) ||
					(e.ToolStrip is ToolStripDropDownMenu))
			{
				// Create border and clipping paths
				using (GraphicsPath borderPath = CreateBorderPath(rect: e.AffectedBounds, cut: _cutContextMenu),
															clipPath = CreateClipBorderPath(rect: e.AffectedBounds, cut: _cutContextMenu))
				{
					// Clip all drawing to within the border path
					using (UseClipping clipping = new UseClipping(g: e.Graphics, path: clipPath))
					{
						// Create the background brush
						using (SolidBrush backBrush = new SolidBrush(color: _contextMenuBack))
						{
							e.Graphics.FillPath(brush: backBrush, path: borderPath);
						}
					}
				}
			}
			else if (e.ToolStrip is StatusStrip)
			{
				// We do not paint the top two pixel lines, so are drawn by the status strip border render method
				RectangleF backRect = new RectangleF(x: 0, y: 1.5f, width: e.ToolStrip.Width, height: e.ToolStrip.Height - 2);

				// Cannot paint a zero sized area
				if ((backRect.Width > 0) && (backRect.Height > 0))
				{
					using (LinearGradientBrush backBrush = new LinearGradientBrush(rect: backRect,
																																				 color1: ColorTable.StatusStripGradientBegin,
																																				 color2: ColorTable.StatusStripGradientEnd,
																																				 angle: 90f))
					{
						backBrush.Blend = _statusStripBlend;
						e.Graphics.FillRectangle(brush: backBrush, rect: backRect);
					}
				}
			}
			else
			{
				base.OnRenderToolStripBackground(e);
			}
		}
		#endregion

		#region OnRenderImageMargin
		/// <summary>
		/// Raises the RenderImageMargin event. 
		/// </summary>
		/// <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
		protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
		{
			if ((e.ToolStrip is ContextMenuStrip) ||
					(e.ToolStrip is ToolStripDropDownMenu))
			{
				// Start with the total margin area
				Rectangle marginRect = e.AffectedBounds;

				// Do we need to draw with separator on the opposite edge?
				bool rtl = (e.ToolStrip.RightToLeft == RightToLeft.Yes);

				marginRect.Y += _marginInset;
				marginRect.Height -= _marginInset * 2;

				// Reduce so it is inside the border
				if (!rtl)
				{
					marginRect.X += _marginInset;
				}
				else
				{
					marginRect.X += _marginInset / 2;
				}

				// Draw the entire margine area in a solid color
				using (SolidBrush backBrush = new SolidBrush(color: ColorTable.ImageMarginGradientBegin))
				{
					e.Graphics.FillRectangle(backBrush, marginRect);
				}

				// Create the light and dark line pens
				using (Pen lightPen = new Pen(color: _separatorMenuLight),
										darkPen = new Pen(color: _separatorMenuDark))
				{
					if (!rtl)
					{
						// Draw the light and dark lines on the right hand side
						e.Graphics.DrawLine(pen: lightPen, x1: marginRect.Right, y1: marginRect.Top, x2: marginRect.Right, y2: marginRect.Bottom);
						e.Graphics.DrawLine(pen: darkPen, x1: marginRect.Right - 1, y1: marginRect.Top, x2: marginRect.Right - 1, y2: marginRect.Bottom);
					}
					else
					{
						// Draw the light and dark lines on the left hand side
						e.Graphics.DrawLine(pen: lightPen, x1: marginRect.Left - 1, y1: marginRect.Top, x2: marginRect.Left - 1, y2: marginRect.Bottom);
						e.Graphics.DrawLine(pen: darkPen, x1: marginRect.Left, y1: marginRect.Top, x2: marginRect.Left, y2: marginRect.Bottom);
					}
				}
			}
			else
			{
				base.OnRenderImageMargin(e);
			}
		}
		#endregion

		#region OnRenderToolStripBorder
		/// <summary>
		/// Raises the RenderToolStripBorder event. 
		/// </summary>
		/// <param name="e">An ToolStripRenderEventArgs containing the event data.</param>
		protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
		{
			if ((e.ToolStrip is ContextMenuStrip) ||
					(e.ToolStrip is ToolStripDropDownMenu))
			{
				// If there is a connected area to be drawn
				if (!e.ConnectedArea.IsEmpty)
				{
					using (SolidBrush excludeBrush = new SolidBrush(color: _contextMenuBack))
					{
						e.Graphics.FillRectangle(excludeBrush, e.ConnectedArea);
					}
				}

				// Create border and clipping paths
				using (GraphicsPath borderPath = CreateBorderPath(e.AffectedBounds, exclude: e.ConnectedArea, cut: _cutContextMenu),
														insidePath = CreateInsideBorderPath(rect: e.AffectedBounds, exclude: e.ConnectedArea, cut: _cutContextMenu),
															clipPath = CreateClipBorderPath(rect: e.AffectedBounds, exclude: e.ConnectedArea, cut: _cutContextMenu))
				{
					// Create the different pen colors we need
					using (Pen borderPen = new Pen(color: ColorTable.MenuBorder),
										 insidePen = new Pen(color: _separatorMenuLight))
					{
						// Clip all drawing to within the border path
						using (UseClipping clipping = new UseClipping(g: e.Graphics, path: clipPath))
						{
							// Drawing with anti aliasing to create smoother appearance
							using (UseAntiAlias uaa = new UseAntiAlias(g: e.Graphics))
							{
								// Draw the inside area first
								e.Graphics.DrawPath(insidePen, path: insidePath);

								// Draw the border area second, so any overlapping gives it priority
								e.Graphics.DrawPath(borderPen, path: borderPath);
							}

							// Draw the pixel at the bottom right of the context menu
							e.Graphics.DrawLine(pen: borderPen, x1: e.AffectedBounds.Right, y1: e.AffectedBounds.Bottom,
																						 x2: e.AffectedBounds.Right - 1, y2: e.AffectedBounds.Bottom - 1);
						}
					}
				}
			}
			else if (e.ToolStrip is StatusStrip)
			{
				// Draw two lines at top of the status strip
				using (Pen darkBorder = new Pen(color: _statusStripBorderDark),
									lightBorder = new Pen(color: _statusStripBorderLight))
				{
					e.Graphics.DrawLine(pen: darkBorder, x1: 0, y1: 0, x2: e.ToolStrip.Width, y2: 0);
					e.Graphics.DrawLine(pen: lightBorder, x1: 0, y1: 1, x2: e.ToolStrip.Width, y2: 1);
				}
			}
			else
			{
				base.OnRenderToolStripBorder(e);
			}
		}
		#endregion

		#region Implementation
		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="button"></param>
		/// <param name="toolstrip"></param>
		private void RenderToolButtonBackground(Graphics g,
																						ToolStripButton button,
																						ToolStrip toolstrip)
		{
			// We only draw a background if the item is selected or being pressed
			if (button.Enabled)
			{
				if (button.Checked)
				{
					if (button.Pressed)
					{
						DrawGradientToolItem(g: g, item: button, colors: _itemToolItemPressedColors);
					}
					else if (button.Selected)
					{
						DrawGradientToolItem(g: g, item: button, colors: _itemToolItemCheckPressColors);
					}
					else
					{
						DrawGradientToolItem(g: g, item: button, colors: _itemToolItemCheckedColors);
					}
				}
				else
				{
					if (button.Pressed)
					{
						DrawGradientToolItem(g: g, item: button, colors: _itemToolItemPressedColors);
					}
					else if (button.Selected)
					{
						DrawGradientToolItem(g: g, item: button, colors: _itemToolItemSelectedColors);
					}
				}
			}
			else
			{
				if (button.Selected)
				{
					// Get the mouse position in tool strip coordinates
					Point mousePos = toolstrip.PointToClient(p: Control.MousePosition);

					// If the mouse is not in the item area, then draw disabled
					if (!button.Bounds.Contains(pt: mousePos))
					{
						DrawGradientToolItem(g: g, item: button, colors: _itemDisabledColors);
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="item"></param>
		/// <param name="toolstrip"></param>
		private void RenderToolDropButtonBackground(Graphics g,
																								ToolStripItem item,
																								ToolStrip toolstrip)
		{
			// We only draw a background if the item is selected or being pressed
			if (item.Selected || item.Pressed)
			{
				if (item.Enabled)
				{
					if (item.Pressed)
					{
						DrawContextMenuHeader(g: g, item: item);
					}
					else
					{
						DrawGradientToolItem(g: g, item: item, colors: _itemToolItemSelectedColors);
					}
				}
				else
				{
					// Get the mouse position in tool strip coordinates
					Point mousePos = toolstrip.PointToClient(p: Control.MousePosition);

					// If the mouse is not in the item area, then draw disabled
					if (!item.Bounds.Contains(pt: mousePos))
					{
						DrawGradientToolItem(g: g, item: item, colors: _itemDisabledColors);
					}
				}
			}

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="splitButton"></param>
		/// <param name="toolstrip"></param>
		private void RenderToolSplitButtonBackground(Graphics g,
																								 ToolStripSplitButton splitButton,
																								 ToolStrip toolstrip)
		{
			// We only draw a background if the item is selected or being pressed
			if (splitButton.Selected || splitButton.Pressed)
			{
				if (splitButton.Enabled)
				{
					if (!splitButton.Pressed && splitButton.ButtonPressed)
					{
						DrawGradientToolSplitItem(g: g, splitButton: splitButton,
																		 colorsButton: _itemToolItemPressedColors,
																		 colorsDrop: _itemToolItemSelectedColors,
																		 colorsSplit: _itemContextItemEnabledColors);
					}
					else if (splitButton.Pressed && !splitButton.ButtonPressed)
					{
						DrawContextMenuHeader(g: g, item: splitButton);
					}
					else
					{
						DrawGradientToolSplitItem(g: g, splitButton: splitButton,
																		 colorsButton: _itemToolItemSelectedColors,
																		 colorsDrop: _itemToolItemSelectedColors,
																		 colorsSplit: _itemContextItemEnabledColors);
					}
				}
				else
				{
					// Get the mouse position in tool strip coordinates
					Point mousePos = toolstrip.PointToClient(p: Control.MousePosition);

					// If the mouse is not in the item area, then draw disabled
					if (!splitButton.Bounds.Contains(pt: mousePos))
					{
						DrawGradientToolItem(g: g, item: splitButton, colors: _itemDisabledColors);
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="item"></param>
		/// <param name="colors"></param>
		private void DrawGradientToolItem(Graphics g,
																			ToolStripItem item,
																			GradientItemColors colors) =>
			// Perform drawing into the entire background of the item
			DrawGradientItem(g, new Rectangle(location: Point.Empty, size: item.Bounds.Size), colors);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="splitButton"></param>
		/// <param name="colorsButton"></param>
		/// <param name="colorsDrop"></param>
		/// <param name="colorsSplit"></param>
		private void DrawGradientToolSplitItem(Graphics g,
																					 ToolStripSplitButton splitButton,
																					 GradientItemColors colorsButton,
																					 GradientItemColors colorsDrop,
																					 GradientItemColors colorsSplit)
		{
			// Create entire area and just the drop button area rectangles
			Rectangle backRect = new Rectangle(location: Point.Empty, size: splitButton.Bounds.Size);
			Rectangle backRectDrop = splitButton.DropDownButtonBounds;

			// Cannot paint zero sized areas
			if ((backRect.Width > 0) && (backRectDrop.Width > 0) &&
					(backRect.Height > 0) && (backRectDrop.Height > 0))
			{
				// Area that is the normal button starts as everything
				Rectangle backRectButton = backRect;

				// The X offset to draw the split line
				int splitOffset;

				// Is the drop button on the right hand side of entire area?
				if (backRectDrop.X > 0)
				{
					backRectButton.Width = backRectDrop.Left;
					backRectDrop.X -= 1;
					backRectDrop.Width++;
					splitOffset = backRectDrop.X;
				}
				else
				{
					backRectButton.Width -= backRectDrop.Width - 2;
					backRectButton.X = backRectDrop.Right - 1;
					backRectDrop.Width++;
					splitOffset = backRectDrop.Right - 1;
				}

				// Create border path around the item
				using (GraphicsPath borderPath = CreateBorderPath(rect: backRect, cut: _cutMenuItemBack))
				{
					// Draw the normal button area background
					DrawGradientBack(g: g, backRect: backRectButton, colors: colorsButton);

					// Draw the drop button area background
					DrawGradientBack(g: g, backRect: backRectDrop, colors: colorsDrop);

					// Draw the split line between the areas
					using (LinearGradientBrush splitBrush = new LinearGradientBrush(new Rectangle(x: backRect.X + splitOffset, y: backRect.Top, width: 1, height: backRect.Height + 1),
																																					color1: colorsSplit.Border1, color2: colorsSplit.Border2, angle: 90f))
					{
						// Sigma curve, so go from color1 to color2 and back to color1 again
						splitBrush.SetSigmaBellShape(focus: 0.5f);

						// Convert the brush to a pen for DrawPath call
						using (Pen splitPen = new Pen(brush: splitBrush))
						{
							g.DrawLine(pen: splitPen, x1: backRect.X + splitOffset, y1: backRect.Top + 1, x2: backRect.X + splitOffset, y2: backRect.Bottom - 1);
						}
					}

					// Draw the border of the entire item
					DrawGradientBorder(g: g, backRect: backRect, colors: colorsButton);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="item"></param>
		private void DrawContextMenuHeader(Graphics g, ToolStripItem item)
		{
			// Get the rectangle the is the items area
			Rectangle itemRect = new Rectangle(location: Point.Empty, size: item.Bounds.Size);

			// Create border and clipping paths
			using (GraphicsPath borderPath = CreateBorderPath(rect: itemRect, cut: _cutToolItemMenu),
													insidePath = CreateInsideBorderPath(rect: itemRect, cut: _cutToolItemMenu),
														clipPath = CreateClipBorderPath(rect: itemRect, cut: _cutToolItemMenu))
			{
				// Clip all drawing to within the border path
				using (UseClipping clipping = new UseClipping(g: g, path: clipPath))
				{
					// Draw the entire background area first
					using (SolidBrush backBrush = new SolidBrush(color: _separatorMenuLight))
					{
						g.FillPath(brush: backBrush, path: borderPath);
					}

					// Draw the border
					using (Pen borderPen = new Pen(color: ColorTable.MenuBorder))
					{
						g.DrawPath(pen: borderPen, path: borderPath);
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="item"></param>
		/// <param name="colors"></param>
		private void DrawGradientContextMenuItem(Graphics g,
																						 ToolStripItem item,
																						 GradientItemColors colors)
		{
			// Do we need to draw with separator on the opposite edge?
			Rectangle backRect = new Rectangle(x: 2, y: 0, width: item.Bounds.Width - 3, height: item.Bounds.Height);

			// Perform actual drawing into the background
			DrawGradientItem(g: g, backRect: backRect, colors: colors);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="backRect"></param>
		/// <param name="colors"></param>
		private void DrawGradientItem(Graphics g,
																	Rectangle backRect,
																	GradientItemColors colors)
		{
			// Cannot paint a zero sized area
			if ((backRect.Width > 0) && (backRect.Height > 0))
			{
				// Draw the background of the entire item
				DrawGradientBack(g: g, backRect: backRect, colors: colors);

				// Draw the border of the entire item
				DrawGradientBorder(g: g, backRect: backRect, colors: colors);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="backRect"></param>
		/// <param name="colors"></param>
		private void DrawGradientBack(Graphics g,
																	Rectangle backRect,
																	GradientItemColors colors)
		{
			// Reduce rect draw drawing inside the border
			backRect.Inflate(width: -1, height: -1);

			int y2 = backRect.Height / 2;
			Rectangle backRect1 = new Rectangle(x: backRect.X, y: backRect.Y, width: backRect.Width, height: y2);
			Rectangle backRect2 = new Rectangle(x: backRect.X, y: backRect.Y + y2, width: backRect.Width, height: backRect.Height - y2);
			Rectangle backRect1I = backRect1;
			Rectangle backRect2I = backRect2;
			backRect1I.Inflate(width: 1, height: 1);
			backRect2I.Inflate(width: 1, height: 1);

			using (LinearGradientBrush insideBrush1 = new LinearGradientBrush(rect: backRect1I, color1: colors.InsideTop1, color2: colors.InsideTop2, angle: 90f),
																 insideBrush2 = new LinearGradientBrush(rect: backRect2I, color1: colors.InsideBottom1, color2: colors.InsideBottom2, angle: 90f))
			{
				g.FillRectangle(brush: insideBrush1, rect: backRect1);
				g.FillRectangle(brush: insideBrush2, rect: backRect2);
			}

			y2 = backRect.Height / 2;
			backRect1 = new Rectangle(x: backRect.X, y: backRect.Y, width: backRect.Width, height: y2);
			backRect2 = new Rectangle(x: backRect.X, y: backRect.Y + y2, width: backRect.Width, height: backRect.Height - y2);
			backRect1I = backRect1;
			backRect2I = backRect2;
			backRect1I.Inflate(width: 1, height: 1);
			backRect2I.Inflate(width: 1, height: 1);

			using (LinearGradientBrush fillBrush1 = new LinearGradientBrush(rect: backRect1I, color1: colors.FillTop1, color2: colors.FillTop2, angle: 90f),
																 fillBrush2 = new LinearGradientBrush(rect: backRect2I, color1: colors.FillBottom1, color2: colors.FillBottom2, angle: 90f))
			{
				// Reduce rect one more time for the innermost drawing
				backRect.Inflate(width: -1, height: -1);

				y2 = backRect.Height / 2;
				backRect1 = new Rectangle(x: backRect.X, y: backRect.Y, width: backRect.Width, height: y2);
				backRect2 = new Rectangle(x: backRect.X, y: backRect.Y + y2, width: backRect.Width, height: backRect.Height - y2);

				g.FillRectangle(brush: fillBrush1, rect: backRect1);
				g.FillRectangle(brush: fillBrush2, rect: backRect2);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="backRect"></param>
		/// <param name="colors"></param>
		private void DrawGradientBorder(Graphics g,
																		Rectangle backRect,
																		GradientItemColors colors)
		{
			// Drawing with anti aliasing to create smoother appearance
			using (UseAntiAlias uaa = new UseAntiAlias(g))
			{
				Rectangle backRectI = backRect;
				backRectI.Inflate(width: 1, height: 1);

				// Finally draw the border around the menu item
				using (LinearGradientBrush borderBrush = new LinearGradientBrush(rect: backRectI, color1: colors.Border1, color2: colors.Border2, angle: 90f))
				{
					// Sigma curve, so go from color1 to color2 and back to color1 again
					borderBrush.SetSigmaBellShape(focus: 0.5f);

					// Convert the brush to a pen for DrawPath call
					using (Pen borderPen = new Pen(brush: borderBrush))
					{
						// Create border path around the entire item
						using (GraphicsPath borderPath = CreateBorderPath(rect: backRect, cut: _cutMenuItemBack))
						{
							g.DrawPath(pen: borderPen, path: borderPath);
						}
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="darkBrush"></param>
		/// <param name="lightBrush"></param>
		private void DrawGripGlyph(Graphics g,
															 int x,
															 int y,
															 Brush darkBrush,
															 Brush lightBrush)
		{
			g.FillRectangle(brush: lightBrush, x: x + _gripOffset, y: y + _gripOffset, width: _gripSquare, height: _gripSquare);
			g.FillRectangle(brush: darkBrush, x: x, y: y, width: _gripSquare, height: _gripSquare);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="g"></param>
		/// <param name="vertical"></param>
		/// <param name="rect"></param>
		/// <param name="lightPen"></param>
		/// <param name="darkPen"></param>
		/// <param name="horizontalInset"></param>
		/// <param name="rtl"></param>
		private void DrawSeparator(Graphics g,
															 bool vertical,
															 Rectangle rect,
															 Pen lightPen,
															 Pen darkPen,
															 int horizontalInset,
															 bool rtl)
		{
			if (vertical)
			{
				int l = rect.Width / 2;
				int t = rect.Y;
				int b = rect.Bottom;

				// Draw vertical lines centered
				g.DrawLine(pen: darkPen, x1: l, y1: t, x2: l, y2: b);
				g.DrawLine(pen: lightPen, x1: l + 1, y1: t, x2: l + 1, y2: b);
			}
			else
			{
				int y = rect.Height / 2;
				int l = rect.X + (rtl ? 0 : horizontalInset);
				int r = rect.Right - (rtl ? horizontalInset : 0);

				// Draw horizontal lines centered
				g.DrawLine(pen: darkPen, x1: l, y1: y, x2: r, y2: y);
				g.DrawLine(pen: lightPen, x1: l, y1: y + 1, x2: r, y2: y + 1);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="exclude"></param>
		/// <param name="cut"></param>
		/// <returns></returns>
		private GraphicsPath CreateBorderPath(Rectangle rect,
																					Rectangle exclude,
																					float cut)
		{
			// If nothing to exclude, then use quicker method
			if (exclude.IsEmpty)
			{
				return CreateBorderPath(rect: rect, cut: cut);
			}

			// Drawing lines requires we draw inside the area we want
			rect.Width--;
			rect.Height--;

			// Create an array of points to draw lines between
			List<PointF> pts = new List<PointF>();

			float l = rect.X;
			float t = rect.Y;
			float r = rect.Right;
			float b = rect.Bottom;
			float x0 = rect.X + cut;
			float x3 = rect.Right - cut;
			float y0 = rect.Y + cut;
			float y3 = rect.Bottom - cut;
			float cutBack = (cut == 0f ? 1 : cut);

			// Does the exclude intercept the top line
			if ((rect.Y >= exclude.Top) && (rect.Y <= exclude.Bottom))
			{
				float x1 = exclude.X - 1 - cut;
				float x2 = exclude.Right + cut;

				if (x0 <= x1)
				{
					pts.Add(new PointF(x: x0, y: t));
					pts.Add(new PointF(x: x1, y: t));
					pts.Add(new PointF(x: x1 + cut, y: t - cutBack));
				}
				else
				{
					x1 = exclude.X - 1;
					pts.Add(new PointF(x: x1, y: t));
					pts.Add(new PointF(x: x1, y: t - cutBack));
				}

				if (x3 > x2)
				{
					pts.Add(new PointF(x: x2 - cut, y: t - cutBack));
					pts.Add(new PointF(x: x2, y: t));
					pts.Add(new PointF(x: x3, y: t));
				}
				else
				{
					x2 = exclude.Right;
					pts.Add(new PointF(x: x2, y: t - cutBack));
					pts.Add(new PointF(x: x2, y: t));
				}
			}
			else
			{
				pts.Add(new PointF(x: x0, y: t));
				pts.Add(new PointF(x: x3, y: t));
			}

			pts.Add(new PointF(x: r, y: y0));
			pts.Add(new PointF(x: r, y: y3));
			pts.Add(new PointF(x: x3, y: b));
			pts.Add(new PointF(x: x0, y: b));
			pts.Add(new PointF(x: l, y: y3));
			pts.Add(new PointF(x: l, y: y0));

			// Create path using a simple set of lines that cut the corner
			GraphicsPath path = new GraphicsPath();

			// Add a line between each set of points
			for (int i = 1; i < pts.Count; i++)
			{
				path.AddLine(pt1: pts[i - 1], pt2: pts[i]);
			}

			// Add a line to join the last to the first
			path.AddLine(pt1: pts[pts.Count - 1], pt2: pts[0]);

			return path;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="cut"></param>
		/// <returns></returns>
		private GraphicsPath CreateBorderPath(Rectangle rect, float cut)
		{
			// Drawing lines requires we draw inside the area we want
			rect.Width--;
			rect.Height--;

			// Create path using a simple set of lines that cut the corner
			GraphicsPath path = new GraphicsPath();
			path.AddLine(x1: rect.Left + cut, y1: rect.Top, x2: rect.Right - cut, y2: rect.Top);
			path.AddLine(x1: rect.Right - cut, y1: rect.Top, x2: rect.Right, y2: rect.Top + cut);
			path.AddLine(x1: rect.Right, y1: rect.Top + cut, x2: rect.Right, y2: rect.Bottom - cut);
			path.AddLine(x1: rect.Right, y1: rect.Bottom - cut, x2: rect.Right - cut, y2: rect.Bottom);
			path.AddLine(x1: rect.Right - cut, y1: rect.Bottom, x2: rect.Left + cut, y2: rect.Bottom);
			path.AddLine(x1: rect.Left + cut, y1: rect.Bottom, x2: rect.Left, y2: rect.Bottom - cut);
			path.AddLine(x1: rect.Left, y1: rect.Bottom - cut, x2: rect.Left, y2: rect.Top + cut);
			path.AddLine(x1: rect.Left, y1: rect.Top + cut, x2: rect.Left + cut, y2: rect.Top);
			return path;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="cut"></param>
		/// <returns></returns>
		private GraphicsPath CreateInsideBorderPath(Rectangle rect, float cut)
		{
			// Adjust rectangle to be 1 pixel inside the original area
			rect.Inflate(width: -1, height: -1);

			// Now create a path based on this inner rectangle
			return CreateBorderPath(rect: rect, cut: cut);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="exclude"></param>
		/// <param name="cut"></param>
		/// <returns></returns>
		private GraphicsPath CreateInsideBorderPath(Rectangle rect,
																								Rectangle exclude,
																								float cut)
		{
			// Adjust rectangle to be 1 pixel inside the original area
			rect.Inflate(width: -1, height: -1);

			// Now create a path based on this inner rectangle
			return CreateBorderPath(rect: rect, exclude: exclude, cut: cut);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="cut"></param>
		/// <returns></returns>
		private GraphicsPath CreateClipBorderPath(Rectangle rect, float cut)
		{
			// Clipping happens inside the rect, so make 1 wider and taller
			rect.Width++;
			rect.Height++;

			// Now create a path based on this inner rectangle
			return CreateBorderPath(rect: rect, cut: cut);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <param name="exclude"></param>
		/// <param name="cut"></param>
		/// <returns></returns>
		private GraphicsPath CreateClipBorderPath(Rectangle rect,
																							Rectangle exclude,
																							float cut)
		{
			// Clipping happens inside the rect, so make 1 wider and taller
			rect.Width++;
			rect.Height++;

			// Now create a path based on this inner rectangle
			return CreateBorderPath(rect: rect, exclude: exclude, cut: cut);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <param name="rect"></param>
		/// <param name="direction"></param>
		/// <returns></returns>
		private GraphicsPath CreateArrowPath(ToolStripItem item,
																				 Rectangle rect,
																				 ArrowDirection direction)
		{
			int x, y;

			// Find the correct starting position, which depends on direction
			if ((direction == ArrowDirection.Left) ||
					(direction == ArrowDirection.Right))
			{
				x = rect.Right - ((rect.Width - 4) / 2);
				y = rect.Y + (rect.Height / 2);
			}
			else
			{
				x = rect.X + (rect.Width / 2);
				y = rect.Bottom - ((rect.Height - 3) / 2);

				// The drop down button is position 1 pixel incorrectly when in RTL
				if ((item is ToolStripDropDownButton) &&
						(item.RightToLeft == RightToLeft.Yes))
				{
					x++;
				}
			}

			// Create triangle using a series of lines
			GraphicsPath path = new GraphicsPath();

			switch (direction)
			{
				case ArrowDirection.Right:
					path.AddLine(x1: x, y1: y, x2: x - 4, y2: y - 4);
					path.AddLine(x1: x - 4, y1: y - 4, x2: x - 4, y2: y + 4);
					path.AddLine(x1: x - 4, y1: y + 4, x2: x, y2: y);
					break;
				case ArrowDirection.Left:
					path.AddLine(x1: x - 4, y1: y, x2: x, y2: y - 4);
					path.AddLine(x1: x, y1: y - 4, x2: x, y2: y + 4);
					path.AddLine(x1: x, y1: y + 4, x2: x - 4, y2: y);
					break;
				case ArrowDirection.Down:
					path.AddLine(x1: x + 3f, y1: y - 3f, x2: x - 2f, y2: y - 3f);
					path.AddLine(x1: x - 2f, y1: y - 3f, x2: x, y2: y);
					path.AddLine(x1: x, y1: y, x2: x + 3f, y2: y - 3f);
					break;
				case ArrowDirection.Up:
					path.AddLine(x1: x + 3f, y1: y, x2: x - 3f, y2: y);
					path.AddLine(x1: x - 3f, y1: y, x2: x, y2: y - 4f);
					path.AddLine(x1: x, y1: y - 4f, x2: x + 3f, y2: y);
					break;
			}

			return path;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private GraphicsPath CreateTickPath(Rectangle rect)
		{
			// Get the center point of the rect
			int x = rect.X + (rect.Width / 2);
			int y = rect.Y + (rect.Height / 2);

			GraphicsPath path = new GraphicsPath();
			path.AddLine(x1: x - 4, y1: y, x2: x - 2, y2: y + 4);
			path.AddLine(x1: x - 2, y1: y + 4, x2: x + 3, y2: y - 5);
			return path;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="rect"></param>
		/// <returns></returns>
		private GraphicsPath CreateIndeterminatePath(Rectangle rect)
		{
			// Get the center point of the rect
			int x = rect.X + (rect.Width / 2);
			int y = rect.Y + (rect.Height / 2);

			GraphicsPath path = new GraphicsPath();
			path.AddLine(x1: x - 3, y1: y, x2: x, y2: y - 3);
			path.AddLine(x1: x, y1: y - 3, x2: x + 3, y2: y);
			path.AddLine(x1: x + 3, y1: y, x2: x, y2: y + 3);
			path.AddLine(x1: x, y1: y + 3, x2: x - 3, y2: y);
			return path;
		}
		#endregion
	}
}
