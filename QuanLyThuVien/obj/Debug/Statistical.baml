   M S B A M L   `   `   `  ����H  DQuanLyThuVien, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:QuanLyThuVienQuanLyThuVien  5   	   Q-clr-namespace:QuanLyThuVien.UserControlCustomQuanLyThuVien.UserControlCustom  5   	       QuanLyThuVien.Statistical   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:QuanLyThuVien     5   	   <uc-clr-namespace:QuanLyThuVien.UserControlCustom     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	      MaterialDesignBody#���   5
   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    
 MainVM � DataContext# [ 5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ Statistical��5   	   $	��450��6   $	��600��6*   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5      2   ,QuanLyThuVien.UserControlCustom.ControlBarUC  6    5      � 5   
   $��1��6    5       �� 5!      6"   �� 5"      6"   .+�5$      � $��0��6   .+�5%      �� ��5&      �� *Items1+ �� View 5'      �� 5(      .P�5)      �� $	��STT��5+   !   	 �� DisplayMemberBinding	 5*   !   �� *Unit+5+   !   �� 5,      $��Loại��5-   !   
 �� CellTemplate
 5.   "   �� 5/   &   .R�50   *   �� $	��100��51      .@�52   .   �� $
��Test��53      �� 54   .   $��Test2��55      �� 56   .   $��Test3��57      58   +   59   '   5;      �� 5<      $��
Tổng thu��5>   !   	 5=   !   �� *TotalRevenue+5>   !   �� 5?      $��
Tổng chi��5A   !   	 5@   !   �� *TotalExpenditure+5A   !   �� 5B      $��Chênh lệch��5D   !   	 5C   !   �� *
Difference+5D   !   5E      5G      5H      � 5I      $��1��6   .+�5J      #  MaterialDesignThemes.Wpf.Card  $��1��6&   $	��600��63   $��80��6?   $��Center=�6K   $��Bottom=�6h   .��5K      �  � 	Resources 5L       �� 
TargetType �� Property �� Value��%V   '�       �� 5M      " �6$   .�5N   "   ��  � ��$ 5q�6;   6G   5O      5P      .+�5S      � $��2��6    � ColumnDefinitions 5T      �� 5U   "   $
��214* �63   6B   �� 5V   "   $
��184* �63   6B   �� 5W   "   $
��183* �63   6B   .+�5Y      (  "System.Windows.Controls.DatePicker  $	��200��5Z   !   $��Center=�5[   !   $��Center=�6<   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Chọn ngày��5\   !    $  MaterialDesignOutlinedDatePicker#��[ 5]   !   $��49��6[   $��3,6,10.6,5.4q�6g   �� 5^      $��1��6%     MaterialDesignRaisedButton#��[ 5_       � ToolTip$% Resource name: Xuất ra giấy��5`      $��Xuất báo cáo��5a      $
��Auto��60   $��32.4,14,28.6,14.4q�6>   �� 5b      $��2��6%   #��[ 5c      $# Resource name: Xuất ra file��5d      $��Thống kê��5e      $
��Auto��6,   $��33.4,14,31.8,14.4q�6:   5f      5g      5h      5i      5j      5k      5l      