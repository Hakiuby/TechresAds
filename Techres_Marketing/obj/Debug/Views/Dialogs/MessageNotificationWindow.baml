   M S B A M L   `   `   `  ????L  HTechres_Marketing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Techres_Marketing.Views.DialogsTechres_Marketing.Views.Dialogs  5   	   C&clr-namespace:Techres_Marketing.HelperTechres_Marketing.Helper  5   	   ?    9Techres_Marketing.Views.Dialogs.MessageNotificationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Techres_Marketing.Views.Dialogs     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   2helps&clr-namespace:Techres_Marketing.Helper  5   	   -   5        $??notificationWindow??5   	   $??Regular"?5	   	   $??13(?5
   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5   	      TextRenderingMode$
 Auto=?5   	    ? WindowStyle$
 None=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? Icon$ 	/logo.ico??5   	    ? WindowStartupLocation$ CenterScreen=?5   	   $
??0.75q?5   	    ? Title$ Thông báo??5   	   $	??250??6   $	??500??6(    ? 	Resources 5       ?? Source?? 5   
   $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml??6   %    .??5      ? 
???????	 ? RowDefinitions	 5   
   ?? 5      $??50 ?6   ?? 5      $??* ?6   ?? 5      $??50 ?6   .+?5   
   ]? $??0??6      	MainBrush#??[  6"   .+?5      ?? $??5 0 0 0q?6   $??40??6%   $??40??60   $??0??6=   $??Uniform=?6M   $??Stretch=?6_   ?? 5       
???????$??17(?6'   $??Center=?6?   $??SemiBold"?6?   ??65   ?? +   %Techres_Marketing.Helper.MessageValue
   MESSAGE_NOTIFICATION ?? Source# Z
 6?   ?? 5!      -   5        $??0 0 0 0q?5!   *   $??Right=?6;   $??Center=?6W   $??0q?6y   
?????? ???	#FF2387D6??6?   Z? .??5"      '  !MaterialDesignThemes.Wpf.PackIcon  $??Center=?6*   $??Center=?6G      Kind$ Close=?6i   
???????$??50??6?   $??25??6?   5#      5$      ?? 5%   
   -   5        $??ContentNotification??5%   ?   $
??10 5q?6   $??1??6"   $??14(?6/   $??Center=?6=   $??Center=?6X   $??Normal$?6u   $
??Wrap=?6?   Overate-vntech.vn6?   ]? 5&   
     GrayBackgroupBrush#??[ 6   $??2??6E   .+?5'      ?? -   5        $??90??5'   ,   $??0 0 10 0q?6X   $??Center=?6j   $??Right=?6?   $??35??6?   ??67   ?? *CloseCommand+.??5(      ?? $??ĐÓNG??6   
???  ??$??Center=?69   $??Center=?6T   
???????6q   5)      5*      5+      5,      