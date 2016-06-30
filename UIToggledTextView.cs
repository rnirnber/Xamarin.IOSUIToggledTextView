using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;
using System.Threading;
namespace NewPower.iOS.CustomUI
{
    public class UIToggledTextView: UITextView
    {
        private List<string> _TextData = new List<string>();
        private List<float> _FontSizes = new List<float>();

        private int _TextDataIndex = 0;

        public void AddBoundItem(string text, float font_size)
        {
            this._TextData.Add(text);
            this._FontSizes.Add(font_size);
        }

        public void CenterAlignText()
        {
          nfloat height = this.Bounds.Height;
          nfloat content_height = this.ContentSize.Height;
          if(content_height < height)
          {
            nfloat diff = height - content_height;
            nfloat halved = diff / ((nfloat) 2.0);
            this.SetContentOffset(new CGPoint(this.ContentOffset.X, halved), false);
            this.ContentOffset = new CGPoint(this.ContentOffset.X, halved);
            this.ContentInset = new UIEdgeInsets(halved, this.ContentInset.Left, 0, 0);
          }
        }

        private void _Update()
        {
          InvokeOnMainThread(() =>
          {                                     
            UIView.Animate(0.45, 0, UIViewAnimationOptions.CurveEaseInOut,
            () =>
            {
               this.Alpha = (nfloat) 1.0;
               this.Alpha = (nfloat) 0.0;
            },
            () =>
            {
              this.Text = this._TextData.ToArray()[this._TextDataIndex];
              this.Font = UIFont.FromName(this.Font.Name, this._FontSizes.ToArray()[this._TextDataIndex]);
              this.CenterAlignText();
              this._IncrementIdx();
              UIView.Animate(0.45, 0, UIViewAnimationOptions.CurveEaseInOut, () =>
              {
                this.Alpha = (nfloat) 0.0;
                this.Alpha = (nfloat) 1.0;
              },
              () => {});
            });
            
          });
        }
        
        private void _IncrementIdx()
        {
          this._TextDataIndex++;
          if(this._TextDataIndex >= this._TextData.Count)
          {
            this._TextDataIndex = 0;
          }
        }
        public void StartToggling(double duration)
        {
            duration += 1;
            if(this._TextData.Count > 0)
            {
              Timer t = new Timer((x) =>
              {
                this._Update();
              }, null, 0, (int) duration * 1000);
            }
        }

    }
}