   M S B A M L   `   `   `  ????L  HTechres_Marketing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Techres_Marketing.Views.UserControls$Techres_Marketing.Views.UserControls  5      C ?FluidKit, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG1clr-namespace:FluidKit.Controls;assembly=FluidKitFluidKit.Controls 5	      B    <Techres_Marketing.Views.UserControls.ShowBirthDayUserControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Techres_Marketing.Views.UserControls     5      Cfluid1clr-namespace:FluidKit.Controls;assembly=FluidKit     5	      $	??120(?5        ? 	Resources  5      '  !FluidKit.Controls.SlideTransition   SlideTransition&   FluidKit.Controls.CubeTransition  CubeTransition   Rotation&   FluidKit.Controls.FlipTransition  FlipTransition??%i   &	        &	      &	 8       5   
   6      5   
   $ BottomToTop=?66     5   
   6   5      .??5      ? .+?5   
   +  %FluidKit.Controls.TransitionPresenter  -   5          Name$ 	TransPres??5   $      
Transition 5      '  !FluidKit.Controls.GenieTransition  5         
EffectType$ IntoLamp=?6(   .@?5      ?? -   5         ??Name$ 
ImgCurrent??5      $??Uniform=?6(    J? Opacity$ 1Q?6:    ? LayoutTransform 5      V? 5      .~?5      ?? -   5        ImgScale?? ?? ScaleX$ 1Q?5   ;   	 ?? ScaleY$	 1Q?6F   ?? 5      -   5        
ImgRot??
 ?? Angle$
 0Q?5   :   5      5      5      r? 5   
   -   5        $??Video??5   "   $??5q?6    r? LoadedBehavior$ Manual=?6/   6I   ? 5    
    ? RowDefinitions 5!      ?? 5"      $??2* ?6    ?? 5#      $??* ?6    .+?5%      ?? $??2??6   .+?5&      ?? -   5        $??TitleBirthDay??5&      $	??100(?61    ?? TextAlignment$ Center=?6@   $??WrapWithOverflow=?6W   $	??Top=?6w   $??Center=?6?   $
??Bold"?6?   
????  ? J? Effect 5'      3  -System.Windows.Media.Effects.DropShadowEffect  5(         
BlurRadius$ 20Q?6+      Color$ White??6;      	Direction$ 0Q?6I      ShadowDepth$ 20Q?6W   5*      ?? 5+      -   5        $??CustomerName??5+      $ Center=?60   $??0 0 0 50q?6G    ?? Padding$ 0 0 0 10q?6Y   $??WrapWithOverflow=?6l   $??Bottom=?6?   $??Center=?6?     HPBD-Customer-Font#??[ 6?   
???  ??$	??100(?6  $
??Bold"?6   5,        5-      $ 20Q?6+   $
 Gray??6;   $ 10Q?6H   $ 10Q?6W   5/      50      51      5?      5?      