   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Remax2019	Remax2019  5   	   &     Remax2019.ViewModel.EmployeePage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Remax2019     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  EmployeePage��5	   	   $	��900��6   $
��1300��6+    � 
ResizeMode$ NoResize=�68    � WindowStyle$
 None=�6N   .��5
      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   .+�5      �� -   5         ��Name$ GridContent��5      60   5      � 5   
   -   5        
���  ��$��1��5       .+�5      �� $
��10,0q�6    �� Orientation$ 
Horizontal=�6'   $��Right=�6@   .+�5      �� $	��300��6   $��5q�6S   ��6%   Z� ��6;   Z� .��5      �� $ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$
 User=�62   �� 5       -   5         ��Name$
 user��5    $   64   5!      5"      �� 5$      -   5        $��25��5$   	   $��5q�6A   ��6   Z� ��6*   Z� .��5%        $ Logout=�6.   5&      5'      5(      � 5+   
   $��1��6    5-      �� 5.      $	��100 �6    �� 5/      $��5* �6    .+�52      � .+�53      �� $��../Assets/top_a3.jpg��6   $
��Fill=�66   $	��120��6E   $��
0,-30,0,10q�6R   54      � 56      $��1��6   .+�57      �� 
�������$��1q�59      	 J� Effect	 5;      3  -System.Windows.Media.Effects.DropShadowEffect  5<      5>      �� 5?      .+�5A      �� -   5        $��9q�5A      
���  ��
���  ��.��6`   	Dashboard6k   �� 5C      -   5        $��9q�5C      
���  ��
���  ��.��6i   
Attendance6u   �� 5E      -   5        $��9q�5E      
���  ��
���  ��.��6c   Loan6i   �� 5H      -   5        $��9q�5H      
���  ��
���  ��.��5I      � .+�5J      �� $ 
Horizontal=�6)   .+�5K      �� -	   5        $ 
leaveNotif��5K   5   $��(0)  ��6(   $��Center=�6I   �� 5L   "   �� 5M      -
   5        $ 	leaveText��5M   <   $��File a leave��6(   $��Center=�6O   5N      5O      5P      �� 5S      -   5        $��9q�5S      
���  ��
���  ��.��5T      � .+�5U      �� $ 
Horizontal=�6)   .+�5V   "   �� -   5        $ overTimeNotif��5V   9   $��(0)  ��6,   $��Center=�6P   �� 5W   "   �� 5X   "   -   5        $ overTimeText��5X   D   $��Request Overtime��6,   $��Center=�6Z   5Y      5Z      5\      5^      5`      5b      5d      5e      