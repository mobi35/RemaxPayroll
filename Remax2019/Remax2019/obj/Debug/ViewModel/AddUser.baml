   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Remax2019	Remax2019  5          Remax2019.AddUser   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Remax2019     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   �� -   5          ��Name$  FullName��5   I   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Enter your full name��6   $��32,-12,833,716q�6[   �� 5   
   -   5        $  UserName��5   X   $) #Enter Username ( 5 - 20 Characters)��6   $��32,84,833,622q�6j   G� 5   
   -   5         G�Name$ PassWord��5   \   $) #Enter Password ( 8 - 20 Characters)��6   $��32,160,833,544q�6n   G� 5   
   -   5        $ ReTypePassword��5   ]   $) #Enter Password ( 8 - 20 Characters)��6   $��32,256,833,449q�6u   �� 5   
   -   5        $  Email��5   H   $ Enter Email Address��6   $��32,326,833,378q�6W   �� 5   
   -   5        $  Address��5   <   $ Address��6   $��307,-12,16,716q�6M   �� 5   
   -   5         ��Name$ Position��5   e   $y�Hidden=�6   $ Choose Position��6'   $��65��6X   $��308,113,559,622q�6w   .@�5      �� $��Employee��6   60   �� 5      $��Admin��6   6-   �� 5      $��HR Staff��6   60   5      �� 5   
   -   5        $ 
PositionHR��5   e   $y�Hidden=�6   $ Choose Position��6'   $��65��6X   $��308,113,559,622q�6y   .@�5      �� $��Employee��6   60   �� 5      $��HR Staff��6   60   5      �� 5    
   -	   5        $ JobTitle��5    E   $ Choose job title��6   $��307,160,559,480q�6W   (  "System.Windows.Controls.DatePicker  5"   
   -
   5          Name$ 	Birthdate��5"      $ 	Birthdate��6(   $��597,103,299,622q�6S   �� 5$   
   -   5        $  	ImageName��5$   D   $ Upload Picture��6   $��597,193,16,544q�6W   �� 5%   
   -   5         ��Name$ allowingLeave��5%   )   $��Allow Leave��6   $��871,316,126,415q�6�   �� 5&   
   -   5        $  AllowedLeaves��5&   p   $ Number of leave��6   $��871,369,25,368q�6�   �� 5'   
   -   5        $
��Auto��5'      $��597,293,347,472q�67   $��Upload��6P   �� 5(   
   $��
300,30,0,0q�6   $��50��6*    �� Orientation$ 
Horizontal=�66   .+�5)      �� $��Gender: ��6   	� 5*      -   5         	�Name$
 Male��5*   %   $��70��6   $
��Male��63    	� 	GroupName$ Gender��6C   	� 5+   
   -   5        $ Female��5+   !   $��70��6   $��Female��61   $ Gender��6B   5,      �� 5-   
   -   5        $
��Auto��5-      $��32,505,884,243q�64   .��6M   Submit6U   50      51      