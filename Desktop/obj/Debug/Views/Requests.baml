   M S B A M L   `   `   `  ����  Desktop    Desktop.Views.Requests   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Y UPrism.Unity.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59S OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Back to main menu��6   $��10q�6Z   $
��Left=�6f   $��Center=�6�   ��6:   �� *BackCommand+6�   �� 5   
   -   5        $
��Save��5      $��0��6   $
��Save��6*   $��10q�6Y   $��Right=�6e   $��Center=�6�   ��69   �� *SaveCommand+6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��RequestsForNewCourses��5       $��1��6   $��10q�6r      AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Extended=�5   +   $��Center=�6D   ��5   =   �� *CoursesRequests+ �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Course Name��6>      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *Name+6S     5      $ Trainer��6E    . 	 6%   �� *TrainerName+6V     5      $
 Room��6B    . 	 6%   �� *
RoomName+6P     5      $ 	StartDate��6C    . 	 6%   �� *	StartTime+6V     5      $ EndDate��6A    . 	 6%   �� *	EndTime+6R     5      $ Total Seats��6L    . 	 6%   �� *TotalNumberOfSeats+6a   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ Approve or refuse��6H   	 6)   �� *
IsApproved+6H   5         5"   
   -   5        $��RequestsForNewEvents��5"       $��2��6   $��10q�6p    .   .  $ Extended=�5#   +   $��Center=�6D   ��5"   <   �� *EventsRequests+$ TwoWay=� 5$        5%      $ 
Event Name��6>    . 	 6%   �� *Name+6R     5&      $ Participation Fee��6J    . 	 6%   �� *ParticipationFee+6e     5'      $
 Room��6B    . 	 6%   �� *
RoomName+6P     5(      $ 	StartDate��6C    . 	 6%   �� *	StartTime+6V     5)      $ EndDate��6A    . 	 6%   �� *	EndTime+6R     5*      $ Number of participants��6H    . 	 6%   �� *NrParticipants+6h     5+      $ Approve or refuse��6H   	 6)   �� *
IsApproved+6H   5-      5/      50      