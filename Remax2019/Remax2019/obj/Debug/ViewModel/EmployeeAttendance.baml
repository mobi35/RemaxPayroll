   M S B A M L   `   `   `  ����D  @Remax2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Remax2019.ViewModelRemax2019.ViewModel  5      ,    &Remax2019.ViewModel.EmployeeAttendance   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Remax2019.ViewModel     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  AttendanceGrid��5
         AutoGenerateColumns .     
IsReadOnly . $��-10,52,10,380q�6Z      RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5      ��  �� Property � �� �� Value
 �����63    �� Triggers 5      �� 5       �� Binding 6&   �� 	 �� Path$	 time_out�.a�5      ��  � ��
 �����6;   �� 5       � ��
 �   �6;   5      �� 5       6&   �� $	 time_in�.a�5      ��  � ��
 ����6;   �� 5       � ��
 �   �6;   5      5      
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5         FontSize$ 11Q�6%   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 64      Header$ Time in��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *	time_in+  5      $ 11Q�6%   $	 200 63   $ Time out��6B    6T   �� *
time_out+5!      5"      5#      