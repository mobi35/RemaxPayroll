   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Remax2019	Remax2019  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      +    %Remax2019.ViewModel.AdminLeaveControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Remax2019     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3system&clr-namespace:System;assembly=mscorlib  5
      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5           Name$  LeaveControl��5   �      AutoGenerateColumns .     
IsReadOnly . "   VerticalScrollBarVisibility$ Hidden=�6A   $   HorizontalScrollBarVisibility$ Hidden=�6f   $��10,47,10,462q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 11Q�6%   ,  &System.Windows.Controls.DataGridColumn   Header$ Leave Title��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *TypeOfLeave+  5      $ Start of Leave��6%    6=   �� *	StartDate+  5      $ End of Leave��6%    6;   �� *	EndDate+  5      $
 Name��6%    63   �� *User+  5      $ Position��6%    67   �� *
Position+  5      $ Status��6%    65   �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  5      	   CellTemplate	 5      �� 5      .R�5      �� 
 �� Orientation$
 
Horizontal=�6*   .+�5   "   ��  ��Name$ accept��6)   -   5        $��20��5   9   $��10(�6E   )  #MaterialDesignThemes.Wpf.DialogHost   OpenDialogCommand#��Z 6f   $��Accept��6�   
 � Tag 6S   �� *Id+��6�   ��  �� ElementName$ isAccept��6�   �� 5    "   $ decline��6V   -   5        $��20��5    )   $��10(�65   #��Z 6g   $��Decline��6�    6C   �� *Id+��6�   �� $ 	isDecline��6�   �� 5!   "   -   5        $��20��5!   )   $��10(�65   $��Show Message��6W    6C   �� *Id+6n   5"      5#      5%      5(        5*   
   -   5        $  LeaveControlHistory��5*   �    .   . $ Hidden=�6A   $ Hidden=�6f   $��0,383,20,126q�6�      RowStyle 5+      �� 5,       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5-      ��  �� Property � �� �� Value
 �����63    �� Triggers 5.      �� 5/       �� Binding 6&   ��  �� Path$ Status� �� Value declined6F   .a�50      ��  � ��
 �����6;   �� 51       � ��
 �   �6;   52      �� 53       6&   �� $ Status� accepted6F   .a�54      ��  � ��
 ����6;   �� 55       � ��
 �   �6;   56      58       5:        5=      $ 11Q�6%   $ Leave Title��65    6J   �� *TypeOfLeave+  5?      $ Start of Leave��6%    6=   �� *	StartDate+  5@      $ End of Leave��6%    6;   �� *	EndDate+  5A      $
 Name��6%    63   �� *User+  5B      $ Position��6%    67   �� *
Position+  5C      $ Status��6%    65   �� *Status+  5D      5F      5I        5K   
   -   5          Name$ isAccept��5K   3      IsOpen .  $��0,-126,0,-32q�6E      DialogContent 5L      �� 5M      $��60 40q�6   $
��Left=�6,   $
 Vertical=�6G   .+�5N      �� $4��.Are you sure you want to accept this leave ? ?��6    $��0 0 0 20q�6V   6j   �� 5O      $
 
Horizontal=�6!   $��Center=�6:   .+�5P      �� -   5        $ accept��5P   �   $	��100��6!      CloseDialogCommand#��Z 6A    6-   �� *Id+��6�   �� $ isAccept��.��6�   Yes6�   �� 5Q      $��     ��6$   �� 5R      $	��100��6!   #��Z 6-   ��6o   �� $ isAccept��.��6�   No6�   5S      5T      5V        5X   
   -   5        $ 	isDecline��5X   3    .  $��0,-126,0,-32q�6F    5Y      �� 5Z      $��60 40q�6   $
��Left=�6,   $
 Vertical=�6G   .+�5[      �� $3��-Are you sure you want to decline this leave ?��6    $��0 0 0 20q�6U   6i   �� 5\      $
 
Horizontal=�6!   $��Center=�6:   .+�5]      �� -	   5        $ decline��5]   �   $	��100��6!   #��Z 6A    6-   �� *Id+��6�   �� $ 	isDecline��.��6�   Yes6�   �� 5^      $��     ��6$   �� 5_      $	��100��6!   #��Z 6-   ��6o   �� $ 	isDecline��.��6�   No6�   5`      5a      5c      5d      5e      