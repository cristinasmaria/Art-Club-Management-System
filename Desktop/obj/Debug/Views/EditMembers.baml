   M S B A M L   `   `   `  ����  Desktop    Desktop.Views.EditMembers   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Y UPrism.Unity.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59S OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  . .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $
��Auto �6#   .+�5      �� $��0��6   $
��Back��6%   $��20 10q�64   $��10q�6C   $
��Left=�6P   ��5      �� *BackToMainMenuCommand+�� 5      $��1��6   $
��Save��6%   $��20 10q�64   $��10q�6C   ��5      �� *SaveCommand+5      &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns .  $��20 20 20 10q�6i      SelectionMode$ Single=�5         CanUserAddRows .  ��5       �� *	Members+ �� Mode$ OneWay=�   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ MemberId��6%   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *
MemberId+6T     5"      $ UserId��6%   	 . 
 65   �� *UserId+6P     5#      $ FullName��6%   	 . 
 67   �� *
FullName+6T     5$      $ Email��6%   	 . 
 64   �� *Email+6N     5%      $ MonthlyPayment��6%   
 6=   �� *MonthlyPayment+  5&      $ TotalNeededPayment��6%   
 6A   �� *TotalNeededPayment+  5'      $ TotalActualPayment��6%   
 6A   �� *TotalActualPayment+5)      �� 5+   
   $��2��6   $��0 0 0 10q�6!   $��Center=�63   $��Center=�6P   
���  ����5,      �� *	Message+6-   5-      5.      