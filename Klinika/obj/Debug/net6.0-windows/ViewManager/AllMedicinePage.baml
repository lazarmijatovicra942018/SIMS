   M S B A M L   `   `   `  ����B  >Klinika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Klinika.ViewManagerKlinika.ViewManager  5      )    #Klinika.ViewManager.AllMedicinePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Klinika.ViewManager     5        N� Title$  AllMedicinePage��5	      .��5      � ���#F7FF93 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��70 �6   .+�5   
   � $��2��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridMedicine��5   -   ���#F7FF93   
IsReadOnly$
 True��6h      SelectionMode$ Single=�5         AutoGenerateColumns$ False��6.   $
��Left=�6J   $	��140��5      $��	10,20,0,0q�6$   $	��Top=�67   $��2��6�   $��Hidden=�6�   $��Hidden=�5      ��5   G   �� *
Medicine+   Columns 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6*      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6M   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� *id+6M     5"      $
 Name��6)   $	 100 6P   	 67   �� *name+6P     5#      $ Quantity��6)   $	 100 6X   	 6;   �� *
quantity+6X     5$      $ 
Manufactur��6)   $	 100 6\   	 6=   �� *
manufactur+6\     5%      $ Price��6)   $	 100 6R   	 68   �� *price+6R     5&      $ Approved��6)   $	 100 6Z   	 6;   �� *
isApproved+6Z   5*      5,      � 5-   
   $��1��6   .+�5/      �� $��RightToLeft=�6   
 �� Orientation$
 
Horizontal=�65   .+�50      �� -   5         ��Name$ searchMaxTextBox��50      $y�Hidden=�64   $��LeftToRight=�6I   $��0��6e   $	��Top=�6r   $��
180,20,0,0q�6�   $��70��6�   $��30��6�   6�   �� 51      -   5        $ searchMinTextBox��51      $y�Hidden=�64   $��LeftToRight=�6H   $��0��6e   $	��Top=�6r   $��	10,20,0,0q�6�   $��70��6�   $��30��6�   6�   53      �� 55      $��RightToLeft=�6   $
 
Horizontal=�65   .+�56      �� -   5        $��sorterCombo��56   �   $��	30,20,0,0q�6I   $��2��6\   $��1��6i   $��15(�6y   $��Center=�6�   $
��Left=�6�   $	��130��6�   $��30��6�   
���   �.@�57      �� $��
imenu leka��6#   $��Center=�68   $��Center=�6U   �� 58      $
��ceni��6#   $��Center=�62   $��Center=�6O   �� 59      $$��preostaloj kolicini u magacinu��6#   $��Center=�6L   $��Center=�6i   5;      �� 5=      -   5        $ searchTextBox��5=      $��0��61   $y�Hidden=�6?   $��LeftToRight=�6S   $	��Top=�6o    �� TextAlignment$
 Left=�6�   $��	30,20,0,0q�6�   $	��130��6�   $��30��6�   6�   �� 5A      -   5        $��filterCombo��5A   �   $��	30,20,0,0q�6K   $��2��6^   $��1��6k   $��15(�6{   $��Center=�6�   $
��Left=�6�   $	��130��6�   $��30��6�   
���   �.@�5B      �� $��po opsegu cene��6#   $��Center=�6<   $��Center=�6Y   �� 5C      $��sifri��6#   $��Center=�63   $��Center=�6P   �� 5D      $��imenu��6#   $��Center=�63   $��Center=�6P   �� 5E      $��proizvodjacu��6#   $��Center=�6:   $��Center=�6W   �� 5G      $��kolicini��6#   $��Center=�66   $��Center=�6S   �� 5H      $��
sastojcima��6#   $��Center=�68   $��Center=�6U   5K      �� 5M      -   5        $
��show��5M   �   $��	20,20,0,0q�6I   $��2��6\   $��1��6i   $��15(�6y   $��Center=�6�   $
��Left=�6�   $	��130��6�   $��30��6�   
���   �.@�5N      �� $��
sve lekove��6#   $��Center=�68   $��Center=�6U   �� 5O      $��odobrene lekove��6#   $��Center=�6=   $��Center=�6Z   �� 5P      $��odbijene lekove��6#   $��Center=�6=   $��Center=�6Z   5S      5U      5V      � 5W   
   $��0��6   .+�5Y      �� $��RightToLeft=�6   $
 
Horizontal=�65   .+�5\      �� $��Candara)�6   $
��Bold"�61   $��Center=�6D   $
��Left=�6_   $��	30,20,0,0q�6{   $��20(�6�   �� 6�   $�: Sortiranje po��6�   6�   �� 5]      -   5        $��searchMaxTextBlock��5]      $y�Hidden=�67   $��Candara)�6K   $
��Bold"�6`   $��Center=�6s   $
��Left=�6�   $��	40,20,0,0q�6�   $��20(�6�   �� 6�   $�: Maks��6�   6�   �� 5^      -	   5        $��searchMinTextBlock��5^      $y�Hidden=�67   $��Candara)�6K   $
��Bold"�6`   $��Center=�6s   $
��Left=�6�   $��	40,20,0,0q�6�   $��20(�6�   �� 6�   $�: Min��6�   6�   �� 5`      $��Candara)�6   $
��Bold"�61   $��Center=�6D   $
��Left=�6_   $��	45,20,0,0q�6{   $��20(�6�   �� 6�   $�: Pretrazi po��6�   6�   �� 5b      $��Candara)�6   $
��Bold"�61   $��Center=�6D   $
��Left=�6_   $��
100,20,0,0q�6{   $��20(�6�   �� 6�   $�	: Prikazi��6�   6�   5f      5g      �� 5i   
   -
   5         ��Name$ DescriptionLabel��5i      $��3��6/   $��Candara)�6<   $
��Bold"�6Q   $y�Hidden=�6d   $��Center=�6x   $
��Left=�6�   $��20(�6�   �� 6�   6�   � 5k   
   $��4��6   .+�5l      �� $��RightToLeft=�6   $
 
Horizontal=�65   .+�5n      �� -   5         ��Name$ componentsButton��5n   �    � ToolTip$ Prikaz Sastojaka leka ��6   $��Sastojci��6;   ���#005555$��Candara)�6d   $
��Bold"�6y   
�������${�False��6�   $��	30,20,0,0q�6�   $	��100��6�   $��30��6�   $��15(�6�   ��6  Z� 6  �� 5p      -   5        $ Description��5p      $��0��6/    �� 
IsReadOnly$
 True��6<   $y�Hidden=�6N   $��LeftToRight=�6b   $	��Top=�6~   $
 Left=�6�   $��	280,0,0,0q�6�   $	��200��6�   $��60��6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn$
 True��5q      5t      5v      5y      5z      