﻿/*
    AvaloniaColorPicker - A color picker for Avalonia.
    Copyright (C) 2021  Giorgio Bianchini
 
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, version 3.
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.
    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System;

namespace AvaloniaColorPicker
{
    internal class AnimatableColourCanvas : Animatable
    {
        public static readonly StyledProperty<Color> RGBProperty = AvaloniaProperty.Register<AnimatableColourCanvas, Color>(nameof(RGB));
        public Color RGB
        {
            get
            {
                return GetValue(RGBProperty);
            }
            set
            {
                SetValue(RGBProperty, value);
            }
        }

        public static readonly StyledProperty<HSV> HSVProperty = AvaloniaProperty.Register<AnimatableColourCanvas, HSV>(nameof(HSV));
        public HSV HSV
        {
            get
            {
                return GetValue(HSVProperty);
            }
            set
            {
                SetValue(HSVProperty, value);
            }
        }

        public static readonly StyledProperty<LAB> LABProperty = AvaloniaProperty.Register<AnimatableColourCanvas, LAB>(nameof(LAB));
        public LAB LAB
        {
            get
            {
                return GetValue(LABProperty);
            }
            set
            {
                SetValue(LABProperty, value);
            }
        }

        private ColorPicker.ColorComponents ColorComponent { get; set; }

        public Image Canvas2D { get; }
        public Image Canvas1D { get; }
        public Image AlphaCanvas { get; }

        private HSVTransition HSVTransition { get; }
        private RGBTransition RGBTransition { get; }
        private LABTransition LABTransition { get; }

        public AnimatableColourCanvas()
        {
            Canvas2D = new Image() { Width = 256, Height = 256 };
            Canvas1D = new Image() { Width = 24, Height = 256, Stretch = Avalonia.Media.Stretch.Fill };
            AlphaCanvas = new Image() { Width = 24, Height = 256, Stretch = Avalonia.Media.Stretch.Fill };

            if (!ColorPicker.TransitionsDisabled)
            {
                this.Transitions = new Transitions();

                HSVTransition = new HSVTransition() { Property = HSVProperty, Duration = new TimeSpan(0, 0, 0, 0, 100) };
                this.Transitions.Add(HSVTransition);

                LABTransition = new LABTransition() { Property = LABProperty, Duration = new TimeSpan(0, 0, 0, 0, 100) };
                this.Transitions.Add(LABTransition);

                RGBTransition = new RGBTransition() { Property = RGBProperty, Duration = new TimeSpan(0, 0, 0, 0, 100) };
                this.Transitions.Add(RGBTransition);
            }
        }


        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == RGBProperty)
            {
                Update(ColorPicker.ColorSpaces.RGB);
            }
            else if (change.Property == HSVProperty)
            {
                Update(ColorPicker.ColorSpaces.HSB);
            }
            else if (change.Property == LABProperty)
            {
                Update(ColorPicker.ColorSpaces.LAB);
            }
        }

        public void UpdateR(byte R, byte G, byte B, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.RGBTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.RGBTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.R;
            
            Color newValue = Color.FromRgb(R, G, B);

            if (this.RGB != newValue)
            {
                this.RGB = newValue;
                
                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.RGB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.RGB);
            }
        }

        public void UpdateG(byte R, byte G, byte B, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.RGBTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.RGBTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.G;

            Color newValue = Color.FromRgb(R, G, B);

            if (this.RGB != newValue)
            {
                this.RGB = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.RGB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.RGB);
            }
        }

        public void UpdateB(byte R, byte G, byte B, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.RGBTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.RGBTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.B;

            Color newValue = Color.FromRgb(R, G, B);

            if (this.RGB != newValue)
            {
                this.RGB = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.RGB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.RGB);
            }
        }

        public void UpdateH(double H, double S, double V, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.HSVTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.HSVTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.H;

            HSV newValue = new HSV(H, S, V);

            if (this.HSV.H != newValue.H || this.HSV.S != newValue.S || this.HSV.V != newValue.V)
            {
                this.HSV = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.HSB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.HSB);
            }
        }

        public void UpdateS(double H, double S, double V, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.HSVTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.HSVTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.S;

            HSV newValue = new HSV(H, S, V);

            if (this.HSV.H != newValue.H || this.HSV.S != newValue.S || this.HSV.V != newValue.V)
            {
                this.HSV = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.HSB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.HSB);
            }
        }

        public void UpdateV(double H, double S, double V, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.HSVTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.HSVTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.B;

            HSV newValue = new HSV(H, S, V);

            if (this.HSV.H != newValue.H || this.HSV.S != newValue.S || this.HSV.V != newValue.V)
            {
                this.HSV = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.HSB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.HSB);
            }
        }

        public void UpdateL(double L, double a, double b, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.LABTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.LABTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.L;

            LAB newValue = new LAB(L, a, b);

            if (this.LAB.L != newValue.L || this.LAB.a != newValue.a || this.LAB.b != newValue.b)
            {
                this.LAB = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.LAB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.LAB);
            }
        }

        public void Updatea(double L, double a, double b, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.LABTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.LABTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.A;

            LAB newValue = new LAB(L, a, b);

            if (this.LAB.L != newValue.L || this.LAB.a != newValue.a || this.LAB.b != newValue.b)
            {
                this.LAB = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.LAB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.LAB);
            }
        }

        public void Updateb(double L, double a, double b, bool instantTransition)
        {
            if (!ColorPicker.TransitionsDisabled)
            {
                if (instantTransition)
                {
                    this.LABTransition.Easing = new InstantEasing();
                }
                else
                {
                    this.LABTransition.Easing = new LinearEasing();
                }
            }

            this.ColorComponent = ColorPicker.ColorComponents.B;

            LAB newValue = new LAB(L, a, b);

            if (this.LAB.L != newValue.L || this.LAB.a != newValue.a || this.LAB.b != newValue.b)
            {
                this.LAB = newValue;

                if (instantTransition)
                {
                    Update(ColorPicker.ColorSpaces.LAB);
                }
            }
            else
            {
                Update(ColorPicker.ColorSpaces.LAB);
            }
        }


        private void Update(ColorPicker.ColorSpaces colorSpace)
        {
            WriteableBitmap canvas2Dimage = null;
            WriteableBitmap canvas1Dimage = null;

            (byte R, byte G, byte B) = (RGB.R, RGB.G, RGB.B);

            (double H, double S, double V) = (HSV.H, HSV.S, HSV.V);
            (double L, double a, double b) = (LAB.L, LAB.a, LAB.b);

            switch (colorSpace)
            {
                case ColorPicker.ColorSpaces.RGB:
                    switch (ColorComponent)
                    {
                        case ColorPicker.ColorComponents.R:
                            canvas1Dimage = AvaloniaColorPicker.RGB.GetR(G, B);
                            canvas2Dimage = AvaloniaColorPicker.RGB.GetGB(R);
                            break;
                        case ColorPicker.ColorComponents.G:
                            canvas1Dimage = AvaloniaColorPicker.RGB.GetG(R, B);
                            canvas2Dimage = AvaloniaColorPicker.RGB.GetRB(G);
                            break;
                        case ColorPicker.ColorComponents.B:
                            canvas1Dimage = AvaloniaColorPicker.RGB.GetB(R, G);
                            canvas2Dimage = AvaloniaColorPicker.RGB.GetRG(B);
                            break;
                    }
                    break;
                case ColorPicker.ColorSpaces.HSB:
                    HSB.HSVToRGB(H, S, V, out R, out G, out B);
                    switch (ColorComponent)
                    {
                        case ColorPicker.ColorComponents.H:
                            canvas1Dimage = HSB.GetH();
                            canvas2Dimage = HSB.GetSB(H);
                            break;
                        case ColorPicker.ColorComponents.S:
                            canvas1Dimage = HSB.GetS(H, V);
                            canvas2Dimage = HSB.GetHB(S);
                            break;
                        case ColorPicker.ColorComponents.B:
                            canvas1Dimage = HSB.GetB(H, S);
                            canvas2Dimage = HSB.GetHS(V);
                            break;
                    }
                    break;
                case ColorPicker.ColorSpaces.LAB:
                    Lab.FromLab(L, a, b, out R, out G, out B);
                    switch (ColorComponent)
                    {
                        case ColorPicker.ColorComponents.L:
                            canvas1Dimage = Lab.GetL(a, b);
                            canvas2Dimage = Lab.GetAB(L);
                            break;
                        case ColorPicker.ColorComponents.A:
                            canvas1Dimage = Lab.GetA(L, b);
                            canvas2Dimage = Lab.GetLB(a);
                            break;
                        case ColorPicker.ColorComponents.B:
                            canvas1Dimage = Lab.GetB(L, a);
                            canvas2Dimage = Lab.GetLA(b);
                            break;
                    }
                    break;
            }

            Canvas2D.Source = canvas2Dimage;
            Canvas1D.Source = canvas1Dimage;
            AlphaCanvas.Source = AvaloniaColorPicker.RGB.GetA(R, G, B);
        }
    }
}
