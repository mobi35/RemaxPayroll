   M S B A M L   `   `   `  ����F  BREMAX-TIMER, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:REMAX_TIMERREMAX_TIMER  5   	       REMAX_TIMER.TimerForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:REMAX_TIMER     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  
MainWindow��5	   	   $��499.546��6   $	��525��6-    � 
ResizeMode$ NoResize=�69    � WindowStyle$
 None=�6O    � 	Resources 5
      +  %REMAX_TIMER.ByteArrayToImageConverter   	converter��%   &	          5   
   6*   5      .��5      � -   5        .+�5   
   � -   5        $��30��5   1   $	��Top=�6=   
���  ��.+�5      �� $��17(�6   $��3q�6&   $
��Left=�62    % !MaterialDesignSubheadingTextBlock#��[ 5      �� 6T   .F�5      �� $��REMAX - Timer ��6   5      6$   �� 5      $��Right=�6    �� Orientation$ 
Horizontal=�65   .+�5      �� $	��300��6   $��5q�6S   ��6%   Z� ��6;   Z� .��5      �� $ 
Horizontal=�6!   .+�5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$
 User=�62   �� 5      -   5         ��Name$ texting��5   $   67   5      5      �� 5      -   5        $��Right=�5      $��25��65   $��5q�6�   ��6@   Z� ��6q   Z� .��5        $ Logout=�6.   5       5!      5#      �� 5$   
   $	��130��6   $	��130��6   
�������
���  ��$��1q�6T   $��10,49,385,321q�6h   ._�5%      �� -   5         ��Name$ AlreadyImage��5%   #   $
��Fill=�6   $	��130��69   $	��130��6E   6U   5&      �� 5'   
   -   5         ��Name$ Dates��5'   *   $��50��6   $��20(�6   $	��300��69   $
��Date��6E   $��10,204,315,246q�6T   6n   �� 5(   
   -   5        $��label1��5(   P   $��44��6   $��Center=�6   $��232,206,66,0q�6:   $	��Top=�6^   $	��227��6v   $��20(�6�   $��a��6�   	 J� RenderTransformOrigin$	 0.5,0.5&�6�   z�5)      V� 5*      .~�5+      �� �� 5,      
 �� AngleX$
 1.323Q�6$   �� 5-      T� 5.       T� X$ -1.71Q�6)   5/      51      &   System.Windows.Controls.DataGrid  52   
   -   5          Name$ Timing��52   q      AutoGenerateColumns .  $   HorizontalScrollBarVisibility$ Disabled=�60   $	��Top=�6Y   $��46,271,55,0q�6�   $	��214��6�      Columns 54      0  *System.Windows.Controls.DataGridTextColumn  55         FontSize$ 11Q�6%   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 63      Header$ Time In��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6R   �� *	time_in+ �� StringFormat$ HH:mm tt��  56      $ 11Q�6%   $	 150 63   $ Time Out��6?    6Q   �� *
time_out+$ HH:mm tt��59      �� 5:   
   $	��200��6   $��30��6    $��Italic$�6,   $��11(�6?   $
��Bold"�6M   $
��Name��6_   $��151,30,174,402q�6k   �� 5;   
   -	   5        $
 Name��5;      $	��200��6"   $��30��6.   $	��asd��6:   $��162,47,163,385q�6E   �� 5<   
   -
   5        $ Username��5<      $	��200��6&   $��30��62   $	��asd��6>   $��162,134,163,298q�6I   �� 5=   
   -   5        $ EmpId��5=      $	��200��6#   $��30��6/   $	��asd��6;   $��162,88,163,344q�6F   �� 5>   
   -   5        $ Position��5>      $��30��6&   $	��asd��62   $��373,47,20,385q�6=   �� 5?   
   $	��200��6   $��30��6    $��Italic$�6,   $��11(�6?   $
��Bold"�6M   $��Employee Id��6_   $��151,69,174,363q�6r   �� 5@   
   $	��200��6   $��30��6    $��Italic$�6,   $��11(�6?   $
��Bold"�6M   $��Username��6_   $��151,114,174,318q�6o   �� 5A   
   $	��200��6   $��30��6    $��Italic$�6,   $��11(�6?   $
��Bold"�6M   $��Position��6_   $��351,30,-26,402q�6o   5C      5D      