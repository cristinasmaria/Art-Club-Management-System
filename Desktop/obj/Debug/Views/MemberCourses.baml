   M S B A M L   `   `   `  ����  Desktop!    Desktop.Views.MemberCourses   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Y UPrism.Unity.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59S OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   .+�5      �� $
��Back��6   $��20 10q�6$   $��10q�63   $
��Left=�6@   ��5      �� *BackToMainMenuCommand+�� 5      $
��Save��6   $��20 10q�6$   $��10q�63   $��Right=�6@   ��5      �� *SaveCommand+5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��Courses��5       $��1��6      AutoGenerateColumns .     SelectionMode$ Single=�6K   $��20 20 20 10q�5      $��Center=�6(      CanUserAddRows .  ��6J   �� *	Courses+ �� Mode$ OneWay=� � 	Resources 5      )  #System.Windows.Controls.DataGridRow �� 
TargetType �� Triggers	 �� Binding
 �� Value �� Property �� Value��%�   '        �� 5      "  6    5      �� 5      	 6&   �� *	IsEnabled+	
 False6D   .a�5       ��  � {� .  6:   5!      5#      5$         Columns 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn   Header$ Course Name��6>      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+6S     5(      $ Trainer��6E    .  6%   �� *TrainerName+6V     5)      $
 Room��6B    .  6%   �� *
RoomName+6P     5*      $ 	StartDate��6C    .  6%   �� *	StartTime+6V     5+      $ EndDate��6A    .  6%   �� *	EndTime+6R     5,      $ Available Seats��6P    .  6%   �� *NumberOfAvailableSeats+6i     5-      $ Total Seats��6L    .  6%   �� *TotalNumberOfSeats+6a   4  .System.Windows.Controls.DataGridCheckBoxColumn  5.      $ Enrolled��6N    6)   �� *IsMemberEnrolled+6N   50      �� 52   
   $��2��6   $��0 0 0 10q�6!   $��Center=�63   $��Center=�6P   
���  ����53      �� *	Message+6-   54      55      