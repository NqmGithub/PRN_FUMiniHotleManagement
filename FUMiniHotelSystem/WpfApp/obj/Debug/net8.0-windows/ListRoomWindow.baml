   M S B A M L   `   `   `  ����A  =WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WpfAppWpfApp  5   	       WpfApp.ListRoomWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:WpfApp     5   	     � Title$  ListRoomWindow��5   	   $	��471��6    $	��800��6-   .��5	      �� $��0,0,5,0q�6   $	��435��6   $	��Top=�6+   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ RoomDataGrid��5
      $	��428��6)   $	��345��66      AutoGenerateColumns$ False��6B   $��Center=�6~   $	��Top=�6�    �� Left$	 450��6�   
 �� Top$ 7��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Room Number��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *
RoomNumber+  5      $ Max capacity��6%    6;   �� *RoomMaxCapacity+  5      $ Price��6%    64   �� *RoomPricePerDay+  5      $ Status��6%    65   �� *
RoomStatus+5      �� 5   
   -   5        $
��BOOK��5      $	 246��6    $	 396��62   $
��Left=�6C   $	��Top=�6^   $��34��6v   $	��172��6�   $��18(�6�   $
��Bold"�6�   6�   �� 5   
   $ 10��6   $
��Wrap=�6%   $��Room Booking��69   $ 10��6M   $
��Left=�6]   $	��Top=�6x   $
��Bold"�6�   $��22(�6�   �� 5   
   $ 25��6   $
��Wrap=�6%   $��Room Number��69   $ 51��6L   $��16(�6\   $��Center=�6j   $	��Top=�6�   �� 5   
   -   5         ��Name$ txtRoomNumber��5      $	 166��6)   	 �� TextWrapping$
	 Wrap=�6;   $ 49��6O   $	��252��6_   $��16(�6k   $��Center=�6y   $	��Top=�6�   �� 5   
   $ 25��6   $
��Wrap=�6%   $��Max Capacity��69   $ 89��6M   $��16(�6]   $��Center=�6k   $	��Top=�6�   �� 5   
   -   5        $ txtCapacity��5      $	 166��6'   $
	 Wrap=�69   $ 87��6M   $	��252��6]   $��16(�6i   $��Center=�6w   $	��Top=�6�   �� 5   
   $ 25��6   $
��Wrap=�6%   $
��Type��69   $	 149��6E   $��16(�6V   $��Center=�6d   $	��Top=�6�   �� 5   
   -   5        $ txtType��5      $	 166��6#   $
	 Wrap=�65   $	 127��6I   $	��252��6Z   $��16(�6f   $��Center=�6t   $	��Top=�6�   �� 5   
   $ 25��6   $
��Wrap=�6%   $	 167��69   $��16(�6J   $��Center=�6X   $	��Top=�6u   �� 6�   $�Price per day��6�   �� 6�   �� 6�   6�   �� 5   
   -   5        $ txtPrice��5      $	 166��6$   $
	 Wrap=�66   $	 165��6J   $	��252��6[   $��16(�6g   $��Center=�6u   $	��Top=�6�   �� 5   
   $ 25��6   $
��Wrap=�6%   $	 209��69   $��16(�6J   $��Center=�6X   $	��Top=�6u   $��Description��6�   �� 5   
   -   5        $ txtDescription��5      $	 166��6*   $
	 Wrap=�6<   $	 207��6P   $	��252��6a   $��16(�6m   $��Center=�6{   $	��Top=�6�   $��50��6�   �� 5   
   $ 25��6   $
��Wrap=�6%   $	 283��69   $��16(�6J   $��Center=�6X   $	��Top=�6u   $��Status��6�   �� 5   
   -   5        $ 	txtStatus��5      $	 166��6%   $
	 Wrap=�67   $	 281��6K   $	��252��6\   $��16(�6h   $��Center=�6v   $	��Top=�6�   �� 5    
   $ 25��6   $
��Wrap=�6%   $	 323��69   $��16(�6J   $��
Start date��6X   $
��Left=�6j   $��Center=�6�   $
��Bold"�6�   �� 5!   
   -	   5        $ txtStart��5!      $	 166��6$   $
	 Wrap=�66   $	 321��6J   $	��252��6[   $��16(�6g   $��Center=�6u   $	��Top=�6�   �� 5"   
   $ 25��6   $
��Wrap=�6%   $	 361��69   $��16(�6J   $��End date��6X   $��Center=�6h   $	��Top=�6�   $
��Bold"�6�   �� 5#   
   -
   5        $ txtEnd��5#      $	 166��6"   $
	 Wrap=�64   $	 359��6H   $	��252��6Y   $��16(�6e   $��Center=�6s   $	��Top=�6�   5%      5&      