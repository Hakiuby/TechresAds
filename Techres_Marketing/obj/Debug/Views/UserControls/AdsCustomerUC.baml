   M S B A M L   `   `   `  ????L  HTechres_Marketing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Techres_Marketing.Views.UserControls$Techres_Marketing.Views.UserControls  5      8    2Techres_Marketing.Views.UserControls.AdsCustomerUC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Z VDevExpress.Mvvm.UI, Version=22.1.0.0, Culture=neutral, PublicKeyToken=382ad28f6ae31f30F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:Techres_Marketing.Views.UserControls     5      X TFontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5      _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         AdsCustomerVM  ? DataContext#  [  5	       ? 	Resources 5       ?? 
TargetType  textBoxDatagrid ?? Property ?? Value  	TblHeader??%?  &	       &	 ?     ?? 5   
   " ??6   .?5      ??  ? ?? ?#bccaf16+   ?? 5       ? ??$ 13(?6)   ?? 5       ? ??$ Center=?62   ?? 5       ? ??$
 Left=?64   ?? 5       ? ??$ 15 0 0 0q?6'   5      ?? 5   
   " ??6   .?5      ??  ? ?? ?#bccaf16+   ?? 5       ? ??$ 16(?6)   ?? 5       ? ??$ DemiBold"?6+   5      5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??65 ?6   ?? 5      ?? 5      $??95 ?6   .+?5!   
   ?? $??0 10 0 0q?6   $??0??6'   .+?5"      ?? $??0??6   $??Center=?6%   $
??Left=?6@   $5??/Danh sách quảng cáo khách hàng đăng kí??6[   $??20(?6?   $??	15 0 0 10q?6?   $??DemiBold"?6?   ???#bccaf16?   ?? 5#      $??1??6   $??	15 0 15 0q?6#   ???#46558a67   5$      &   System.Windows.Controls.DataGrid  5%   
   $??1??6      RowDetailsVisibilityMode$ Visible=?6       SelectionMode$ Extended=?6C      GridLinesVisibility$
 None=?6\   	   AutoGenerateColumns	 .  
   CanUserAddRows
 .  
??????    CanUserDeleteRows .    CanUserReorderColumns .     CanUserResizeColumns .     CanUserSortColumns . $??0q?5&   ?   $??35 0 0 0q?6?   ??6?   ?? *
ListVideos+   	CellStyle 5:      ?? 5;      *  $System.Windows.Controls.DataGridCell"  6   .?5<      ??  ? ??$ 
0,0.25,0,0q?68   ?? 5=       ? ??$ 45??62   6?   ?? 5>      -  'System.Windows.Input.KeyboardNavigation ?@ 	IsTabStop .  6E   ?? 5?       ? ?? 5@      L? 5A       j? Viewport$ 0,0,4,4?6+    j? ViewportUnits$ Absolute=?6>    j? TileMode$
 Tile=?6W    L? Drawing 5B   "   I? 5C   &   .??5D   *   ?   ColorForegroundBrush ? Brush# [ 6:    ? Geometry 5E   .   ? 5F   2   .??5G   6   ??  ?? Rect$ 	0,0,30,30?6H   ?? 5H   6   $ 30,30,30,30?6H   5I   3   5K   +   5L   '   5N      5P       ?? Triggers 5Q      P? 5R       P? Property ?@ 
IsSelected P? Value . . ?5S      ??  ? ?? ?#4953856;   5U      5X         Columns 5Z      4  .System.Windows.Controls.DataGridTemplateColumn  5e      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6)      
IsReadOnly .    Header 5f      ?? 5g      $??Tên quảng cáo??6$   #??[ 69   6^      CellTemplate 5j      ?? 5k      .R?5l      ?? #??[ 6>   ??6(   ?? *Name+6i   5m      5o        5p      $ * 6)    .  5q      ?? 5r      $??Thời gian??6$   #??[ 65   6Z    5t      ?? 5u      .R?5v      ?? #??[ 6C   ??6(   ?? *	TimeVideo+6n   5w      5y        5z      $
 1.5* 6)    .  5{      ?? 5|      $??Trạng thái??6$   #??[ 66   6[    5~      ?? 5      .R?5?      ?? $
??Left=?6G   $??Center=?6b   $??25 0 0 0q?6}   $??25??6?   ??6$   ?? *IsRunningString+6?   5?      5?      5?      ? 5?   
   ???#31407b$??2??6$    ? ColumnDefinitions 5?      ?? 5?      ?? 5?      ?? 5?      ?? 5?      .+?5?      ?? $??0??6     ?? CornerRadius$  20??6%   $??1q?67   ???#495385$??45??6`   $
??Left=?6l   $??15 0 0 0q?6?   ._?5?      ?? 
?????? 
?????? $
??Left=?6L   ??6g   ?? *PreViewCommand+??5?      ]? 5?      .+?5?      !  FontAwesome.Sharp.IconImage  ?  ?FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.1.1.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]!   Icon$! Tv=?6+   "   
Foreground" ?#bccaf1$??	15 0 15 0q?6J   $??20??6]   ?? 5?      $??Xem trước??6(   ???#bccaf1$??0 0 15 0q?6N   5?      5?      5?      ?? 5?      $??1??6   $  20??6%   $??1q?67   ???#495385$??45??6`   $
??Left=?6l   $??15 0 0 0q?6?   ._?5?      ?? 
?????? 
?????? $
??Left=?6L   ??5?      ]? 5?      .+?5?        $! 
VolumeMute=?6+   " ?#bccaf1$??25??6R   $??	15 0 15 0q?6]   ?? 5?      $??Xem trước??6(   ???#bccaf1$??0 0 15 0q?6N   5?      5?      5?      ?? 5?      $??2??6   $  20??6%   $??1q?67   ???#495385$??45??6`   $
??Left=?6l   $??15 0 0 0q?6?   ._?5?      ?? 
?????? 
?????? $
??Left=?6L   ??6g   ?? *PauseCommand+??5?      ]? 5?      .+?5?        $! Pause=?6+   " ?#bccaf1$??20??6M   $??
 15 0 15 0q?6X   ?? 5?      $??Tạm dừng??6(   ???#bccaf1$??0 0 15 0q?6M   5?      5?      5?      ?? 5?      $??3??6   $  20??6%   $??1q?67   ???#495385$??45??6`   $
??Left=?6l   $??15 0 0 0q?6?   ._?5?      ?? 
?????? 
?????? $
??Left=?6L   ??6g   ?? *ShowAdsCommand+??5?      ]? 5?      .+?5?        $
! Play=?6+   " ?#bccaf1$??18??6L   $??	10 0 10 0q?6W   $??Center=?6j   ?? 5?      $??Trình phát??6(   ???#bccaf1$??0 0 15 0q?6O   5?      5?      5?      5?      5?      5?      