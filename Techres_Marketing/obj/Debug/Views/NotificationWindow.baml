   M S B A M L   `   `   `  ????L  HTechres_Marketing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Techres_Marketing.ViewsTechres_Marketing.Views  5   	   0    *Techres_Marketing.Views.NotificationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   1local%clr-namespace:Techres_Marketing.Views  5   	   -   5        $??notificationWindow??5   	   $??Regular"?5	   	   $??14(?5
   	      	MainBrush#??[  5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?5   	      TextRenderingMode$
 Auto=?5   	    ? WindowStyle$
 None=?5   	    ? 
ResizeMode$ NoResize=?5   	    ? Icon$ 	/logo.ico??5   	   $??1q?5   	    ? WindowStartupLocation$ CenterScreen=?5   	   $
??0.75q?5   	    ? Title$ Thông báo??5   	   $	??250??6   $	??500??6(   .??5      ?   
GrayLBrush#??[ 6    ? RowDefinitions 5   
   ?? 5      $??50 ?6   ?? 5      $??* ?6   ?? 5      $??50 ?6   .+?5   
   ]? $??0??6   ???#ffa233.+?5      ?? $??5 0 0 0q?6   $??40??6%   $??40??60   $??0??6=   $??../logo.ico??6M   $??Uniform=?6b   $??Stretch=?6t   ?? 5       
???????$??20(?6'   $??Center=?65   $??THÔNG BÁO??6X   ?? 5!      -   5        $??0 0 0 0q?5!   *   $??Right=?6;   $??Center=?6W   $??0q?6y   
?????? ???	#FF2387D6??6?   Z? .??5"      '  !MaterialDesignThemes.Wpf.PackIcon  $??Center=?6*   $??Center=?6G      Kind$ Close=?6i   
???????$??50??6?   $??25??6?   5#      5$      ?? 5%   
   
???????$??5q?6$   $??1??6/   $	??0.6q?6<     LineListViewBrush#??[ 6R   ._?5&      ?? -   5        $??ContentNotification??5&   ?   $
??10 5q?6   $??14(?6&   $??Center=?64   $??Center=?6O   $??Normal$?6l   $
??Wrap=?6   6?   5'      ]? 5(   
   $??2??6   .+?5)      ?? $??90??6   $??Right=?6    
???  ??
???????$??Center=?6a   $??0 0 20 0q?6|   $??35??6?   $	??0.6q?6?   	 ?? CornerRadius$	 3??6?   ._?5*      ?? -   5        $??0q?5*      
?????? $??Stretch=?6[   $??Stretch=?6y   $??ĐÓNG??6?   
???  ??5+      5,      5-      5.      5/      