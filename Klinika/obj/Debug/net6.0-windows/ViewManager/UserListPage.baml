   M S B A M L   `   `   `  ����B  >Klinika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Klinika.ViewManagerKlinika.ViewManager  5      &     Klinika.ViewManager.UserListPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Klinika.ViewManager     5        N� Title$  UserListPage��5	      .��5      � ���#F7FF93 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��70 �6   .+�5   
   � $��0��6   .+�5      �� $��RightToLeft=�6    �� Orientation$ 
Horizontal=�65   .+�5      �� $��Candara)�6   $
��Bold"�61   $��Center=�6D   $
��Left=�6_   $��	30,20,0,0q�6{   $��20(�6�   �� 6�   $�: Sortiranje po��6�   6�   �� 5      $��Candara)�6   $
��Bold"�61   $��Center=�6D   $
��Left=�6_   $��	80,20,0,0q�6{   $��20(�6�   �� 6�   $�: Filtrirati ��6�   6�   5"      5#      � 5$   
   $��1��6   .+�5%      �� $��RightToLeft=�6   $ 
Horizontal=�65   .+�5&      �� -   5        $��	sortCombo��5&   �   $��	30,20,0,0q�6K   $��2��6^   $��1��6k   $��15(�6{   $��Center=�6�   $
��Left=�6�   $	��130��6�   $��30��6�   
���   �.@�5'      �� $��imenu ��6#   $��Center=�64   $��Center=�6Q   �� 5(      $��	prezimenu��6#   $��Center=�67   $��Center=�6T   5*      �� 5+      -   5        $��filterCombo��5+   �   $��	30,20,0,0q�6M   $��2��6`   $��1��6m   $��15(�6}   $��Center=�6�   $
��Left=�6�   $	��130��6�   $��30��6�   
���   �.@�5,      �� $��	Farmaceut��6#   $��Center=�67   $��Center=�6T   �� 5-      $��Menadzer��6#   $��Center=�66   $��Center=�6S   �� 5.      $��Doktor ��6#   $��Center=�65   $��Center=�6R   �� 5/      $��Svi korisnici ��6#   $��Center=�6<   $��Center=�6Y   51      54      55      � 56   
   $��2��6    � ColumnDefinitions 57      �� 58      $
��554* �6#   �� 59      $
��247* �6#   .+�5>      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridUsers��5>   -   ���#F7FF93   
IsReadOnly$
 True��6e      SelectionMode$ Single=�5?         AutoGenerateColumns$ False��6.   $
��Left=�6J   $	��145��5@      $��5,20,0,0q�6$   $	��Top=�66   $��2��6�   $��Hidden=�6�   $��Hidden=�5A      ��5>   D   �� *
Medicine+   Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6*   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 85 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 68   �� *name+6Q     5E      $	 	Last name��6)   $
 85 6Y    6<   �� *
lastName+6Y     5F      $
	 Jmbg��6)   $
 70 6P    67   �� *jmbg+6P     5G      $	 E-mail��6)   $	
 135 6S    69   �� *email+6S     5H      $	 Phone number��6)   $
 85 6_    6?   �� *phoneNumber+6_     5I      $	 	User type��6)   $
 85 6Y    6<   �� *
userType+6Y     5J      $	 Baned��6)   $
 70 6T    68   �� *	isBaned+6T   5L      5N      � 5O   
   $��4��6   .+�5P      �� $��RightToLeft=�6   $ 
Horizontal=�65   .+�5R      �� -   5         ��Name$ Blocade��5R   �    � ToolTip$&  Blokiranje oznacenog korisnika .��6   $��Blokiraj��6E   ���#005555$��Candara)�6n   $
��Bold"�6�   
�������${�False��6�   $��	30,20,0,0q�6�   $	��100��6�   $��30��6�   $��15(�6�   ��6	  Z� 6   �� 5S      -   5        $ 	UnBlocade��5S   �   $( "Odblokiranje oznacenog korisnika .��6   $��
Odblokiraj��6G   ���#005555$��Candara)�6r   $
��Bold"�6�   
�������${�False��6�   $��	30,20,0,0q�6�   $	��100��6�   $��30��6�   $��15(�6�   ��6  Z� 6&  5W      5Y      5Z      5[      