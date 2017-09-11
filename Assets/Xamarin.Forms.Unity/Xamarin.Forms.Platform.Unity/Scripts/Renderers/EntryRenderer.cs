﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Xamarin.Forms.Platform.Unity
{
	public class EntryRenderer : ViewRenderer<Entry, UnityEngine.UI.InputField>
	{
		/*-----------------------------------------------------------------*/
		#region Field

		UnityEngine.UI.Text _componentText;
		UnityEngine.Color _defaultTextColor;

		#endregion

		/*-----------------------------------------------------------------*/
		#region MonoBehavior

		protected override void Awake()
		{
			base.Awake();

			var inputField = UnityComponent;
			if (inputField != null)
			{
				_componentText = inputField.textComponent;
				if (_componentText != null)
				{
					//	Prefab の設定値がデフォルトカラー
					_defaultTextColor = _componentText.color;
				}
			}
		}

		#endregion

		/*-----------------------------------------------------------------*/
		#region Event Handler

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				base.OnElementChanged(e);

				if (e.NewElement != null)
				{
					//_isInitiallyDefault = Element.IsDefault();

					UpdateText();
					UpdateTextColor();
					UpdateFont();
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Entry.TextProperty.PropertyName)
			{
				UpdateText();
			}
			else if (e.PropertyName == Entry.TextColorProperty.PropertyName)
			{
				UpdateTextColor();
			}
			else if (e.PropertyName == Entry.FontSizeProperty.PropertyName ||
				e.PropertyName == Entry.FontAttributesProperty.PropertyName)
			{
				UpdateFont();
			}

			base.OnElementPropertyChanged(sender, e);
		}

		#endregion

		/*-----------------------------------------------------------------*/
		#region Internals

		void UpdateText()
		{
			if (_componentText != null)
			{
				_componentText.text = Element.Text;
			}
		}

		void UpdateTextColor()
		{
			_componentText?.SetTextColor(Element.TextColor, _defaultTextColor);
		}

		void UpdateFont()
		{
			_componentText?.SetFont(Element);
		}

		#endregion
	}
}
