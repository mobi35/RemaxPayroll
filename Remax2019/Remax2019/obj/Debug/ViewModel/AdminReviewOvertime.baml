   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Remax2019.ViewModelRemax2019.ViewModel  5      -    'Remax2019.ViewModel.AdminReviewOvertime   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Remax2019.ViewModel     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  AdminOvertime��5         AutoGenerateColumns .     
IsReadOnly . $��
0,30,0,480q�6Y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 11Q�6%   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 64      Header$
 Name��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *name+  5      $ 11Q�6%   $	 200 63   $
 Date��6B    6P   �� *	date_ot+  5      $ 11Q�6%   $	 200 63   $ Overtime Until��6B    6[   �� *
until_time+ �� StringFormat$ 	hh:mm: tt��4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6)   .+�5   "   �� $
��    ��6,   �� 5   "    ��Name$ acceptOvertime��6V   -   5        $��20��5   )   $��10(�65   )  #MaterialDesignThemes.Wpf.DialogHost   OpenDialogCommand#��Z 6n   $��Accept��6�   
 � Tag 6C   �� *id+��6�   ��  �� ElementName$ isOvertimeAccept��6�   �� 5   "   $
��    ��6,   �� 5   "   $ declineOvertime��6V   -   5        $��20��5   )   $��10(�65   #��Z 6o   $��Decline��6�    6C   �� *id+��6�   �� $ isOvertimeDecline��6�   �� 5   "   $
��    ��6,   5      5      5!      5$        5&   
   -   5        $  AdminOvertimeHistory��5&       .   . $��0,343,0,155q�6`      RowStyle 5'      �� 5(       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5)      ��  �� Property � �� �� Value
 �����63    �� Triggers 5*      �� 5+       �� Binding 6&   ��  �� Path$ status� �� Value declined6F   .a�5,      ��  � ��
 �����6;   �� 5-       � ��
 �   �6;   5.      �� 5/       6&   �� $ status� accepted6F   .a�50      ��  � ��
 ����6;   �� 51       � ��
 �   �6;   52      54       56        57      $ 11Q�6%   $	 200 64   $
 Name��6C    6Q   �� *name+  58      $ 11Q�6%   $	 200 63   $
 Date��6B    6P   �� *	date_ot+  59      $ 11Q�6%   $	 200 63   $ Overtime Until��6B    6[   �� *
until_time+$ 	hh:mm: tt��  5:      $ 11Q�6%   $	 200 63   $ Status��6C    6S   �� *status+5?        5B   
   -   5          Name$ isOvertimeDecline��5B   3      IsOpen .  $��0,-138,0,-20q�6N      DialogContent 5C      �� 5D      $��60 40q�6   $
��Left=�6,   $
 Vertical=�6G   .+�5E      �� $(��"Do you want to decline this leave?��6    $��0 0 0 20q�6J   6^   �� 5F      $
 
Horizontal=�6!   $��Center=�6:   .+�5G      �� -   5        $ declineOvertime��5G   �   $	��100��6!      CloseDialogCommand#��Z 6A    6-   �� *id+��6�   �� $ isOvertimeDecline��.��6�   Yes6�   �� 5H      $��     ��6$   �� 5I      $	��100��6!   #��Z 6-   ��6o   �� $ isOvertimeDecline��.��6�   No6�   5J      5K      5M        5S   
   -   5        $ isOvertimeAccept��5S   3    .  $��0,-138,0,-20q�6M    5T      �� 5U      $��60 40q�6   $
��Left=�6,   $
 Vertical=�6G   .+�5V      �� $'��!Do you want to accept this leave?��6    $��0 0 0 20q�6I   6]   �� 5W      $
 
Horizontal=�6!   $��Center=�6:   .+�5X      �� -   5        $ acceptOvertime��5X   �   $	��100��6!   #��Z 6A    6-   �� *id+��6�   �� $ isOvertimeAccept��.��6�   Yes6�   �� 5Y      $��     ��6$   �� 5Z      $	��100��6!   #��Z 6-   ��6o   �� $ isOvertimeAccept��.��6�   No6�   5[      5\      5^      5_      5`      