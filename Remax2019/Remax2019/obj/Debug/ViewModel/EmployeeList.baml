   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Remax2019	Remax2019  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5
      &     Remax2019.ViewModel.EmployeeList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Remax2019     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      3system&clr-namespace:System;assembly=mscorlib  5
      $
��1200��5      $
��1000��6,     � 	Resources  5      )  #Remax2019.ByteArrayToImageConverter   	converter��%   &	          5   
   6*   5      .��5      � .+�5   
   �� $��
0,-10,0,10q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5         AutoGenerateColumns .     
IsReadOnly . $	��772��5   �   ��5   *   �� *
borrower+ �� SelectedItem 5      �� *id+ �� Mode$ TwoWay=�   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5        5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 90 6-      Header$  ��68   	   CellTemplate	 5      �� 5      .R�5   "   �� $	��250��6(   $��Uniform=�64   $	��120��6G   $	��150��6W   $��70��6f   ��6r   �� *	picture+
 �� 	Converter#
 [  5      5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 11Q�6)   $	 200 67   $ 
EmployeeID��6D   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6X   �� *
employeeId+  5      $ 11Q�6)   $	 400 67   $ 	Full Name��6C    6V   �� *name+  5       $ Username��6)    6;   �� *
username+  5!      	 5"      �� 5$      .R�5%   "   ��  �� Orientation$ 
Horizontal=�6-   .+�5&   &   ��  ��Name$ deleteMember��6Z   -   5        $��20��5&   -   $��10(�69   )  #MaterialDesignThemes.Wpf.DialogHost   OpenDialogCommand#��Z 6p   $��Delete��6�   
 � Tag 6G   �� *id+��6�   ��  �� ElementName$ isDelete��6�   �� 5'   &   $
��    ��60   �� 5(   &   $ editMemberClick��6\   -   5        $��20��5(   .   $��10(�6;   #��Z 6u   $
��Edit��6�    6I   �� *id+��6�   �� $ editMemberDialog��6�   �� 5)   &   $
��    ��60   5+   #   5,      5.      ��50      �� 51       �� 
TargetType)	  #System.Windows.Controls.DataGridRow" 	 6   .�52      -   5        54      56      �� 57      $ 
Horizontal=�6   $��Right=�64   $	��718��6P   .+�58      �� -   5         ��Name$ 
searchUser��58   &   $	��200��6   )
  #MaterialDesignThemes.Wpf.HintAssist 
  Hint$ Search��6b   �� 59      $��10q�6   �� 5:      -   5        $��Previous��5:   *   �� 5;      $��10q�6   �� 5<      -   5        $ currentPage��5<      $��20��6/   
�������$��1��6M   6V   �� 5=      $��10q�6   �� 5>      -   5        $��
   Next   ��5>      6.   5?      5@        5A   
   -	   5          Name$ isDelete��5A   3      IsOpen .  $��0,-126,0,-32q�6E      DialogContent 5B      �� 5C      $��60 40q�6   $
��Left=�6,   $ Vertical=�6G   .+�5D      �� $3��-Are you sure you want to delete this member ?��6    $��0 0 0 20q�6U   6i   �� 5E      $ 
Horizontal=�6!   $��Center=�6:   .+�5F      �� -
   5        $ deleteMember��5F   �   $	��100��6!      CloseDialogCommand#��Z 6K    6-   �� *borrowers_id+��6�   �� $ isDelete��.��6�   Yes6�   �� 5G      $��     ��6$   �� 5H      $	��100��6!   #��Z 6-   ��6o   �� $ isDelete��.��6�   No6�   5I      5J      5L        5P   
   -   5        $ editMemberDialog��5P   3    .   5Q      �� 5R      $��60 40q�6   $
��Left=�6,   $ Vertical=�6G   .+�5S      �� -   5        $ MemberId��5S   2   $y�Hidden=�6   $	��150��6D   ��6Q   ��  �� Path$ id�$ TwoWay=��� 5T      $ 
Horizontal=�6!   .+�5V      �� $��Center=�6$   $��Full Name: ��6@   6U   �� 5W      -   5        $ 	FirstName��5W   "   $	��150��65   ��6B   �� $
 name�$ TwoWay=�5Y      �� 5Z      $ 
Horizontal=�6!   .+�5[      �� $��Center=�6$   $��	Address: ��6?   6R   �� 5\      -   5        $ Address��5\   "   $	��350��63   ��6?   �� $ address�$ TwoWay=�6m   �� 5]      $��Center=�6$   $��Email Address: ��6?   6X   �� 5^      -   5        $
 Area��5^   "   $	��235��60   ��6<   �� $ email�$ TwoWay=�6h   5_      �� 5`      $ 
Horizontal=�6!   .+�5a      �� $��Center=�6$   $��Age: ��6?   6N   �� 5b      -   5        $	 Age��5b   4    �� 
IsReadOnly . $	��150��6A   ��6M   �� $	 age�$ TwoWay=�6w   5d      �� 5e      $ 
Horizontal=�6!   .+�5f      �� $��Center=�6$   $��Job Title: ��6?   6T   �� 5h      -   5         ��Name$ JobTitle��5h   �   $ Choose job title��6R   $��0,0,20,0q�6�    �� Text 6$   �� $ 	job_title�$ TwoWay=�6�   �� 5j      $��Center=�6   $��Allowed Leaves: ��6(   6B   �� 5k      -   5        $ AllowedLeave��5k   .   $	��150��6"   ��6D   �� $ allowable_leaves�$ TwoWay=�6z   5m      �� 5q      $ 
Horizontal=�6!   .+�5r      �� -   5        $��Insert Image��5r   #   6:   �� 5s      $��5q�6$   �� 5t      -   5        $ 	ImageName��5t   N   $ 
Image Name��6"   $��Center=�6b   $	��220��6}   �� 5u      $��20q�6$   �� 5v      $��Center=�6$   $��
Position: ��6?   �� 5w      -   5        $ Position��5w   p   $y�Hidden=�6#   $	��220��67    6C   �� $ position�$ TwoWay=�.@�5x      �� $��Employee��6+   6@   �� 5y      $��Admin��6+   6=   �� 5z      $��HR Staff��6+   6@   5{      �� 5|      -   5        $ 
PositionHR��5|   �   $��
-220 0 0 0q�6#   $y�Hidden=�67   $	��220��6K    6W   �� $ position�$ TwoWay=�.@�5}      �� $��Employee��6+   6@   �� 5~      $��HR Staff��6+   6@   5      5�      �� 5�      �� 5�      �� 5�      $ 
Horizontal=�6!   $��Center=�6:   .+�5�      �� -   5        $ ConfirmUpdate��5�   -   $	��100��6!   #��Z 6b   .��6�   Update6�   �� 5�      $	��   ��6$   �� 5�      $	��100��6!   #��Z 6.   .��6q   Cancel6y   5�      5�      5�      5�      5�      