   M S B A M L   `   `   `  ????L  HTechres_Marketing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Techres_Marketing.ViewsTechres_Marketing.Views  5   	   C&clr-namespace:Techres_Marketing.HelperTechres_Marketing.Helper  5   	   V RXamlAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=20a987d8023d9690J6clr-namespace:XamlAnimatedGif;assembly=XamlAnimatedGifXamlAnimatedGif 5
   	   )    #Techres_Marketing.Views.LoginWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   1local%clr-namespace:Techres_Marketing.Views  5   	   3select&clr-namespace:Techres_Marketing.Helper  5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   @gif6clr-namespace:XamlAnimatedGif;assembly=XamlAnimatedGif  5
   	   -   5        $??loginWindow??5   	     ? WindowStartupLocation$  CenterScreen=?5       ? WindowStyle$
 None=?6?    ? AllowsTransparency .    LoginVM ? DataContext# [  5   	    ? Title$ LoginWindow??5   	   $	??700??6   $
??1200??6*    ? 	Resources 5        	FontVibes ?? 
TargetType ?? Property ?? Value  bg	 ?? 	UriSource??%?   &	       &	 l     ?? 5   
   " ??6"   .?5      ??  ? ??$, &/Resources/Font/GreatVibes-Regular.otf)?6+   5      ?? 5   
   $G	 A/Techres_Marketing;component/Resources/Images/bg_login_window.gif??6!   5      .  (System.Windows.Interactivity.Interaction
   Triggers
 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closed??6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   ?? *ClosedAppCommand+   CommandParameter 5   $   ??  ?? ElementName$ loginWindow??6[   5        5   
   $ Loaded??6   . 5         6$   ?? *
LoadWindow+ 5   $   ?? $ loginWindow??6[   5      .??5      ? ??5    
   ?? 5!       ?? 
StartPoint$ 0.1,0&?6"    ?? EndPoint$ 0.9 , 1&?65   .??5"      ?  ? Color$ #EA4335??6    ? Offset$	 0.9Q?6/   ? 5#      $ #FFA233??6   $	 0.5Q?6/   5$      .+?5&   
   ?? $	??650??6   $	??Top=?6   $??0 20 0 0q?66    ?? CornerRadius$ 180 0 180 0??6H   
???????5(      ?? 5)   
    ?? Orientation$ 
Horizontal=?6   .+?5*      ?? $	??730??6   $	??500??6%   $??Center=?62   $??Center=?6O   .+?5+      ?? '  !XamlAnimatedGif.AnimationBehavior   	SourceUri$+ %\Resources\Images\bg_login_window.gif??6   $	??700??6`   $	??400??6l   $??	30 60 0 0q?6y   $
??Fill=?6?   5,      ?? 5-      
?????? $??1 1 1 1q?6.   $ 22??6H   $??Center=?6Z   $	??550??6u   $??45 0 0 0q?6?   ._?55      ?? $	??350??6   .+?56      #  MaterialDesignThemes.Wpf.Card  +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=?6*   $??0q?6[   $	??520??6g   $	??350??6t   $
??0 10q?6?      UniformCornerRadius$ 20Q?6?   .??57      ?? $??20 40q?6%   .+?59      ]? $??0 0 0 50q?6(   $??Center=?6:   $??Center=?6U   .+?5:   "   ?? $ ??/Resources/Images/logo.png??6(   $??50??6L   $
??Left=?6W   ?? 5;   "   $??10 0 0 0q?6-   .+?5<   &   ]? .+?5=   *   ?? $??TECHRES??64   $??25(?6C   $??Center=?6Q   $??	ExtraBold"?6n   $??KodchiangUPC, Verdana)?6?   ??5>   .   ?? 5?   2   $ 0.1,0&?6F   $ 0.9 , 1&?6Y   .??5A   6   ? $ #FFA233??6C   $	 0.6Q?6S   5B   3   5D   +   5E   '   ?? 5F   &   $&?? Phần mềm quảng cáo số 1??60   $??11(?6O   $??0 5 0 0q?6]   $??DemiBold"?6n   $??Center=?6?   $??Comic Sans MS, Italy)?6?   ??5G   *   ?? 5H   .   $ 0.1,0&?6B   $ 0.9 , 1&?6U   .??5J   2   ? $ #FFA233??6?   $	 0.1Q?6O   5K   /   5M   '   5N   #   5O      ?? 5P      $ 
Horizontal=?6)   $??10q?6B   .+?5Q   "   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ 
Restaurant=?6:   $??25??6L   $??25??6W   ??5R   &   ?? 5S   *   $ 0.1,0&?6>   $ 0.9 , 1&?6Q   .??5T   .   ? $ #EA4335??6;   $	 0.2Q?6K   ? 5U   .   $ #FFA233??6;   $	 0.8Q?6K   5V   +   5X   #   ?? 5Y   "   -   5         ??Name$ txtRestaurantname??5Y   *   $
??10 0q?6E   )	  #MaterialDesignThemes.Wpf.HintAssist 	  Hint$ Nhập tên nhà hàng??6S   
?????? 
???   ?$	??250??6?   
???   ? ?? 
CaretBrush ?	#FFD94448 ?? SelectionBrush ?	#FFD94448??6  ?? *RestaurantName+ ?? UpdateSourceTrigger$ PropertyChanged=?5Z      ?? 5[      $ 
Horizontal=?6)   $??10q?6B   .+?5\   "     $
 User=?6:   $??25??6F   $??25??6Q   ??5]   &   ?? 5^   *   $ 0.1,0&?6>   $ 0.9 , 1&?6Q   .??5_   .   ? $ #EA4335??6;   $	 0.6Q?6K   ? 5`   .   $ #FFA233??6;   $	 0.8Q?6K   5a   +   5c   #   ?? 5d   "   -   5        $ txtUsername??5d   *   $
??10 0q?6?   $ Nhập tên đăng nhập??6M   
???   ?$	??250??6?   
???   ? ?	#FFD94448 ?	#FFD94448??6?   ?? *
UserName+$ PropertyChanged=?5e      ?? 5f      $ 
Horizontal=?6)   $??10q?6B   .+?5g   "     $
 Lock=?6:   $??25??6F   $??25??6Q   ??5h   &   ?? 5i   *   $ 0.1,0&?6>   $ 0.9 , 1&?6Q   .??5j   .   ? $ #EA4335??6;   $	 0.6Q?6K   ? 5k   .   $ #FFA233??6;   $	 0.8Q?6K   5l   +   5n   #   ? 5o   "   .+?5p   &   G? -   5         G?Name$ txtPassword??5p   2     G? PasswordChar$  *??6G   $??10,0,0,0q?5q   2   5
   /Techres_Marketing.Helper.SelectAllFocusBehavior! 
  Enable! . $ ********??5s   2   
???   ?$	??250??6o   
???   ?" G? 
CaretBrush" ?	#FFD94448# G? SelectionBrush# ?	#FFD94448
 5t   *     5u   .   $ PasswordChanged??6=   . 5v   2      6H   ?? *PasswordChangedCommand+ 6s   ?? $ txtPassword??5w   /   5y   '   5z   #   5{      ?? 5|      $??	25 25 0 0q?6)   $ 
Horizontal=?6<   .+?5}   "   ?? $??12(?6+   $??0 0 0 0q?69   $ d? 	IsChecked$ 6K   ?? *CaseSensitive+$ PropertyChanged=? 5~   &   % ?? 
TargetType& ? RowDefinitions' ? ColumnDefinitions  LineListViewBrush( A?Name  	MainBrush) ??Name* ?? Triggers+ P? Property, P? Value- ?? 
TargetName??%?  '??       7  7  7  ?? 5   *   " ??6J   .?5?   .   ??  ?@?Cursor$
 Hand??6G   6V   ?? 5?   .    ? ??$  ??6H   6S   ?? 5?   .    ? ?? 5?   2   ?? 5?   6   "% ??6F   .R?5?   :   ? & 5?   >   ?? 5?   B   $??20 ?6P   6^   ' 5?   >   ?? 5?   B   $??20 ?6S   6`   ?? 5?   B   6V   .+?5?   >   ?? 
???????8??  $ 15??6?   $??1q?6?   $??19??6?   $??19??6?   $??Center=?6?   ._?5?   B   ? .+?5?   F   A? $( outerEllipse??6N   $??0??6d   8?? $??4q?6?   5?   G   5?   C   5?   ?   ?? 5?   >   $) content??6_   $??1??6O   $??5,0,0,0q?6p   $
??Left=?6?   $??Center=?6?   5?   ;   * 5?   :   P? 5?   >   + ?@d?	IsChecked$
, TrueY?6[   . ?5?   B   ?? $- outerEllipse??6I   8   ? ??5?   C   5?   ?   P? 5?   >   + ?@d?	IsChecked$, FalseY?6[   . ?5?   B   ?? $- outerEllipse??6I    ? ??
 ?????5?   C   5?   ?   5?   7   5?   /   5?   +   5?   '   5?   #   ?? 5?   "   $??Lưu mật khẩu??6,   $??Center=?6@   $??5 0 0 0q?6[   
???   ?6l   5?      ?? 5?      $??10q?6)   $??Center=?65   .+?5?   "   ?? -   5        . ??Name$. btnLogin??5?   5   $	??200??5?   )   $??40??65     MaterialDesignRaisedButton#??[ 6A   $??	0 15 0 15q?6v   +  %MaterialDesignThemes.Wpf.ButtonAssist/   CornerRadius$/ 10??6?   $??2q?5?   %   
?????? 
???????0 ? ToolTip$0 Login??5?   %   $??Đăng nhập??6?   ??6G   ?? *LoginCommand+??6h   ?? $ loginWindow????5?   &   ?? 5?   *   $ 0.1,0&?6>   $ 0.9 , 1&?6Q   .??5?   .   ? $ #EA4335??6;   $	 0.9Q?6K   ? 5?   .   $ #FFA233??6;   $	 0.5Q?6K   5?   +   5?   #   5?      5?      5?      5?      5?      5?      ?? 5?   
   $ 
Horizontal=?6   $	??Top=?6.   $??Right=?6F   .+?5?      ?? .+?5?      ?? $??	0 25 0 0 q?6x   
?????? 
?????? ??6   ?? *MinimizeWindowCommand+??6C   ?? $ loginWindow??.??5?        $ Minus=?6.   $??30??6;   $??30??6F   ???#EA43356R   5?      5?      ?? 5?      .+?5?      ?? $??	0 25 0 0 q?6o   
?????? 
?????? ??6   ?? *CloseCommand+??6:   ?? $ loginWindow??.??5?        $ Close=?6.   $??30??6;   $??30??6F   ???#EA43356R   5?      5?      5?      5?      5?      