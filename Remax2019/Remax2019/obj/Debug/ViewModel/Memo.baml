   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Remax2019.ViewModelRemax2019.ViewModel  5          Remax2019.ViewModel.Memo   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Remax2019.ViewModel     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   �� $	��500��6   $��40q�6!   .+�5   
   �� -   5          ��Name$  Title��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Title��6!   $��Center=�6I   ���	#FFF5DCEB6d   �� 5      �� 5      -   5        $  Message��5      $ Message��6'   $	��200��6P   $	��Top=�6^    �� TextWrapping$
 Wrap=�6    �� AcceptsReturn . ���	#FFF5DCEB6�   �� 5   
   -   5        $��5q�5      $	��200��68   .��6E   Send6L   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ MemoList��5         AutoGenerateColumns .     
IsReadOnly . $��10,344,10,10q�5   A      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 11Q�6%   ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Memo Title��65   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6I   �� *
memo_title+  5      $ 11Q�6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 300 63   $	 Memo Message��6?   
 6U   �� *memo_message+  5      $
	 Date��6%   
 63   �� *date+4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6)   .+�5   "   �� $
��    ��6,   �� 5   "    ��Name$ editMemberClick��6X   -   5        $��20��5   *   $��10(�67   )  #MaterialDesignThemes.Wpf.DialogHost   OpenDialogCommand#��Z 6q   $
��Edit��6�   
 � Tag 6E   �� *id+��6�   ��  �� ElementName$ editMemberDialog��6�   �� 5   "   $
��    ��6,   �� 5    "   $ deleteMember��6V   -   5        $��20��5    )   $��10(�65   #��Z 6}   $��Archive��6�    6C   �� *id+��6�   �� $ isDelete��6�   5!      5"      5$      ��5'      �� 5(       �� 
TargetType)	  #System.Windows.Controls.DataGridRow" 	 6   .�5)      -   5        5+      5-        5.   
   -   5          Name$ isDelete��5.   3      IsOpen .  $��-2,-126,2,-286q�6E      DialogContent 5/      �� 50      $��60 40q�6   $
��Left=�6,   $ Vertical=�6G   .+�51      �� $3��-Are you sure you want to delete this member ?��6    $��0 0 0 20q�6U   6i   �� 52      $ 
Horizontal=�6!   $��Center=�6:   .+�53      �� -	   5        $ deleteMember��53   �   $	��100��6!      CloseDialogCommand#��Z 6K    6-   �� *borrowers_id+��6�   �� $ isDelete��.��6�   Yes6�   �� 54      $��     ��6$   �� 55      $	��100��6!   #��Z 6-   ��6o   �� $ isDelete��.��6�   No6�   56      57      59        5>   
   -
   5        $ editMemberDialog��5>   3    .   5?      �� 5@      $��60 40q�6   $
��Left=�6,   $ Vertical=�6G   .+�5A      �� -   5        $  MemoId��5A   2   $y�Hidden=�6   $	��150��6B   ��6O   ��  �� Path$ id� �� Mode$ TwoWay=��� 5B      $ 
Horizontal=�6!   5E      �� 5F      $	��500��6!   $ Vertical=�6.   .+�5G      �� -   5        $  ETitle��5G   "   $ Title��62   $��Center=�6�   ���	#FFF5DCEB��6Y   �� $ 
memo_title�$ TwoWay=�6�   �� 5H      -   5        $  EMessage��5H   "   $ Message��64   $	��200��6�   $	��Top=�6�   $
 Wrap=�6�    . ���	#FFF5DCEB��6]   �� $ memo_message�$ TwoWay=�6�   5J      �� 5P      �� 5Q      �� 5S      $ 
Horizontal=�6!   $��Center=�6:   .+�5U      �� -   5        $ ConfirmUpdate��5U   -   $	��100��6!   #��Z 6b   .��6�   Update6�   �� 5V      $	��   ��6$   �� 5W      $	��100��6!   #��Z 6.   .��6q   Cancel6y   5Y      5Z      5\      5^      5_      