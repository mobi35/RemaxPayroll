   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Remax2019	Remax2019  5   	       Remax2019.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Remax2019     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  
MainWindow��5	   	   $	��900��6   $
��1300��6)    � 
ResizeMode$ NoResize=�66    � WindowStyle$
 None=�6L   .��5
      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   � $��1��6   $��1��6   .+�5      �� -   5         ��Name$ GridContent��5      60   5      � 5   
   -   5        
���  ��$��1��5       .+�5      �� $
��10,0q�6    �� Orientation$ 
Horizontal=�6'   $��Right=�6@   .+�5      �� $	��300��6   $��5q�6S   ��6%   Z� ��6;   Z� .��5      �� $ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$
 User=�62   �� 5       -   5         ��Name$ texting��5        63   5!      5"      �� 5%      -   5        $��25��5%      $��5q�6Q   ��6$   Z� ��6:   Z� .��5&        $ Logout=�6.   5'      5)      5*      � 5-   
   $��1��6    50      �� 51      $	��100 �6    �� 52      $��5* �6    .+�55      � .+�56      �� $��../Assets/top_a3.jpg��6   $
��Fill=�66   $	��120��6E   $��
0,-30,0,10q�6R   57      � 59      $��1��6   $��0,169,0,-169q�6    .+�5:      �� 
�������$��1q�5<      $��0,-174,0,174q�6)   	 J� Effect	 5>      3  -System.Windows.Media.Effects.DropShadowEffect  5?      5A      �� 5C      -   5        $ 
AdminPanel��5C   F   $��
0 -150 0 0q�6   $y�Hidden=�61   .+�5E      �� -   5        $��9q�5E      
���  ��
���  ��.��6_   	Dashboard6j   �� 5F      -   5        $��9q�5F      
���  ��
���  ��.��6^   
Employee6h   �� 5G      -	   5        $��9q�5G      
���  ��
���  ��.��6_   
Accounts6i   �� 5H      -
   5        $��9q�5H      
���  ��
���  ��.��6]   	Payroll6f   �� 5I      -   5        $��9q�5I      
���  ��
���  ��.��6b   Create Memo6o   �� 5J      -   5        $��9q�5J      
���  ��
���  ��.��6\   Loan6b   �� 5K      -   5        $��9q�5K      
���  ��
���  ��.��6]   Leaves6e   �� 5L      -   5        $��9q�5L      
���  ��
���  ��.��6`   
Overtime6j   �� 5M      -   5        $��9q�5M      
���  ��
���  ��.��6`   Add Job Title6o   �� 5N      -   5        $��9q�5N      
���  ��
���  ��.��6_   	Holiday6h   5P      �� 5R      -   5        $ HRPanel��5R   E   $��
0 -150 0 0q�6   $y�Hidden=�61   .+�5T      �� -   5        $��9q�5T      
���  ��
���  ��.��6^   
Employee6h   �� 5U      -   5        $��9q�5U      
���  ��
���  ��.��6_   
Accounts6i   �� 5W      -   5        $��9q�5W      
���  ��
���  ��.��6b   Create Memo6o   �� 5X      -   5        $��9q�5X      
���  ��
���  ��.��6]   Leaves6e   �� 5Y      -   5        $��9q�5Y      
���  ��
���  ��.��6`   
Overtime6j   5\      5^      5`      5b      5c      