   M S B A M L   `   `   `  ????L  HTechres_Marketing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Techres_Marketing.HelperTechres_Marketing.Helper  5   	   5clr-namespace:Techres_MarketingTechres_Marketing  5   	   "    Techres_Marketing.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   3helper&clr-namespace:Techres_Marketing.Helper  5   	   +localclr-namespace:Techres_Marketing  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   -   5        $??
mainWindow??5
   2     ? WindowState$  	Maximized=?6    ? Title$ 
MainWindow??5   	   $	??740??6   $
??1280??6)    ? WindowStyle$
 None=?66    ? AllowsTransparency . 
??????  ? WindowStartupLocation$ CenterScreen=?6|   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$
 Load??6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   ?? *LoadedWindowCommand+	   CommandParameter	 6L   ?? 
 ?? ElementName$
 
mainWindow??6?   5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??300 ?6   ?? 5      $??* ?6   .+?5   
   ?? $??0??6    ?? CornerRadius$ 	10 0 0 10??6!   ??5      ?? 5       ?? 
StartPoint$ 0.5,0&?6&    ?? EndPoint$ 0.5,1&?69   .??5      ?  ? Color$ #223266??6#    ? Offset$ 0Q?63   ? 5      $ #27396b??6#   $ 1Q?63   5      ._?5       ?  ? RowDefinitions 5!      ?? 5"      $??* ?6$   ?? 5#      $	??150 ?6$   .+?5'      ?? .+?5(      ?? .+?5)      ??  ?? Orientation$ 
Horizontal=?6%   $??Center=?6>   $??0 35 0 0q?6[   .+?5*      ?? $ 10??6%   $??40??67   $??40??6B   ??5+   "   ?? 5,   &   $	 0,0&?6:   $	 1,2&?6K   .??5-   *   ? $ #7f7cf1??67   $ 0Q?6G   ? 5.   *   $ #d3b7ff??67   $ 1Q?6G   5/   '   ._?52   "   ?? $??PH??6,   
???????$??22(?6I   $??SemiBold"?6W    ?? TextAlignment$ Center=?6m   $??Center=?6?   $??2 0 0 2q?6?   53      ?? 54      $??10 0 0 0q?6)   $??Center=?6;   .+?55   "   ?? $??Phan Viet Ha??6,   $??15(?6@   $??0 0 0 5q?6N   ???#c2cfff6_   ?? 56   "   $??Beta 1.3??6,   $??11(?6<   $??0 0 0 5q?6J   ???#7788bf6[   57      58      59      ?? 5;      $	??0.8??6    $??20 30q?6-   ???#46558a6<   ?? 5>         menuButtonActive#??[  6   ??6G   ?? *AdsCustomerCommand+??6n   ?? $
 
mainWindow??.??5?      ?? $ 
Horizontal=?6%   .+?5@      !  FontAwesome.Sharp.IconImage  ?  ?FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Star=?6+     memuButtonIcon#??[ 67   ?? 5A      $??Quảng cáo khách hàng??6(     menuButtonText#??[ 6D   5B      5C      ?? 5D        
menuButton#??[ 6   ??6A   ?? *AdsRestaurantCommand+??6j   ?? $
 
mainWindow??.??5E      ?? $ 
Horizontal=?6%   .+?5F        $ Restroom=?6+   #??[ 6;   ?? 5G      $??Quảng cáo nhà hàng??6(   #??[ 6B   5H      5I      ?? 5J      #??[ 6   ??6A   ?? *BirthdayCommand+??6e   ?? $
 
mainWindow??.??5K      ?? $ 
Horizontal=?6%   .+?5L        $ BirthdayCake=?6+   #??[ 6?   ?? 5M      $+??%Chúc mừng sinh nhật khách hàng??6(   #??[ 6N   5N      5O      ?? 5P      #??[ 6   ??6A   ?? *ImageShareAloLineCommand+??6n   ?? $
 
mainWindow??.??5Q      ?? $ 
Horizontal=?6%   .+?5S      ?? $ 5??6%   $??	35 0 20 0q?66   $??23??6I   $??23??6T   ???	#FF6673B7$??2q?6x    - )MaterialDesignToolBarMainPanelBorderStyle#??[ 6?   ._?5T   "   ?? $ Vertical=?6-   $??Center=?6D   .+?5U   &   ?? $	??ALO??60   ???	#FF6673B7$??7(?6R   $
??Bold"?6_   ?? 5V   &   $
??LINE??60   ???	#FF6673B7$??7(?6S   $
??Bold"?6`   5W   #   5X      ?? 5Y      $(??"Danh sách chia sẻ ảnh ALOLINE??6(   #??[ 6M   5Z      5[      ?? 5\      #??[ 6   $??0 25 0 0q?6A   ??6S   ?? *CloseCommand+.??5]      ?? $ 
Horizontal=?6%   .+?5^        $ PowerOff=?6+   #??[ 6;   ?? 5_      $??Thoát??6(   $??DemiBold"?65   #??[ 6K   5`      5a      5d      ?? 5e      $??1??6   $>??8Sản phẩm được phát triển bởi Overate-VnTech??6)   $??13(?6\   $??DemiBold"?6j   ???#a5a1f5$??Center=?6?   $??Bottom=?6?   $??0 0 0 15q?6?   5f      5h      ?? 5k   
   -   5        $??1??5k      $ 	0 10 10 0??6!   ??5l      ?? 5m      $	 1,0&?6&   $	 0,1&?67   .??5n      ? $ #41518f??6#   $ 0Q?63   ? 5o      $  #27396b??6#   $ 1Q?64   5p      ._?5r      ?? -   5        $??	ContentCt??5r        	MainBrush#??[ 6.   5s      5t      5u      