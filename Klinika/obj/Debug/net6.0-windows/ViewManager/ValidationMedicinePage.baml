   M S B A M L   `   `   `  ����B  >Klinika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Klinika.ViewManagerKlinika.ViewManager  5      0    *Klinika.ViewManager.ValidationMedicinePage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Klinika.ViewManager     5        N� Title$  ValidationMedicinePage��5	      .��5      � ���#F7FF93 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��30 �6   �� 5      $��70 �6   .+�5   
   � $��2��6    � ColumnDefinitions 5      �� 5      $	��89* �6#   �� 5      $	��11* �6#   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridMedicine��5   -   ���#F7FF93   
IsReadOnly$
 True��6h      SelectionMode$ Single=�5          AutoGenerateColumns$ False��6.   $
��Left=�6J   $	��120��5!      $��	75,40,0,0q�6$   $	��Top=�67   $��Hidden=�6�   $��Hidden=�5"      ��5   G   �� *
Medicine+   Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6*   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 100 6M   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *id+6M     5&      $
 Name��6)   $		 100 6P   
 67   �� *name+6P     5'      $ Quantity��6)   $		 100 6X   
 6;   �� *
quantity+6X     5(      $ 
Manufactur��6)   $		 100 6\   
 6=   �� *
manufactur+6\     5)      $ Price��6)   $		 100 6R   
 68   �� *price+6R   5-      5/      � 50   
   $��1��6   .+�52      �� $��RightToLeft=�6    �� Orientation$ 
Horizontal=�65   .+�53      �� -   5         ��Name$ searchMaxTextBox��53      $y�Hidden=�64   $��LeftToRight=�6I   $��0��6e   $	��Top=�6r   $��
180,20,0,0q�6�   $��70��6�   $��30��6�   6�   �� 54      -   5        $ searchMinTextBox��54      $y�Hidden=�64   $��LeftToRight=�6H   $��0��6e   $	��Top=�6r   $��	10,20,0,0q�6�   $��70��6�   $��30��6�   6�   56      �� 58      $��RightToLeft=�6   $ 
Horizontal=�65   .+�59      �� -   5        $��sorterCombo��59   �   $��	30,20,0,0q�6I   $��2��6\   $��1��6i   $��15(�6y   $��Center=�6�   $
��Left=�6�   $	��130��6�   $��30��6�   
���   �.@�5:      �� $��
imenu leka��6#   $��Center=�68   $��Center=�6U   �� 5;      $
��ceni��6#   $��Center=�62   $��Center=�6O   �� 5<      $$��preostaloj kolicini u magacinu��6#   $��Center=�6L   $��Center=�6i   5>      �� 5@      -   5        $ searchTextBox��5@      $��0��61   $y�Hidden=�6?   $��LeftToRight=�6S   $	��Top=�6o    �� TextAlignment$
 Left=�6�   $��	30,20,0,0q�6�   $	��130��6�   $��30��6�   6�   �� 5C      -   5        $��filterCombo��5C   �   $��	30,20,0,0q�6K   $��2��6^   $��1��6k   $��15(�6{   $��Center=�6�   $
��Left=�6�   $	��130��6�   $��30��6�   
���   �.@�5D      �� $��po opsegu cene��6#   $��Center=�6<   $��Center=�6Y   �� 5E      $��sifri��6#   $��Center=�63   $��Center=�6P   �� 5F      $��imenu��6#   $��Center=�63   $��Center=�6P   �� 5G      $��proizvodjacu��6#   $��Center=�6:   $��Center=�6W   �� 5I      $��kolicini��6#   $��Center=�66   $��Center=�6S   �� 5J      $��
sastojcima��6#   $��Center=�68   $��Center=�6U   5M      5O      5P      � 5Q   
   $��0��6   .+�5S      �� $��RightToLeft=�6   $ 
Horizontal=�65   .+�5V      �� $��Candara)�6   $
��Bold"�61   $��Center=�6D   $
��Left=�6_   $��	30,20,0,0q�6{   $��20(�6�   �� 6�   $�: Sortiranje po��6�   6�   �� 5W      -   5        $��searchMaxTextBlock��5W      $y�Hidden=�67   $��Candara)�6K   $
��Bold"�6`   $��Center=�6s   $
��Left=�6�   $��	40,20,0,0q�6�   $��20(�6�   �� 6�   $�: Maks��6�   6�   �� 5X      -   5        $��searchMinTextBlock��5X      $y�Hidden=�67   $��Candara)�6K   $
��Bold"�6`   $��Center=�6s   $
��Left=�6�   $��	40,20,0,0q�6�   $��20(�6�   �� 6�   $�: Min��6�   6�   �� 5Z      $��Candara)�6   $
��Bold"�61   $��Center=�6D   $
��Left=�6_   $��	45,20,0,0q�6{   $��20(�6�   �� 6�   $�: Pretrazi po��6�   6�   5^      5_      �� 5a   
   -	   5         ��Name$ DescriptionLabel��5a      $��3��6/   $��Candara)�6<   $
��Bold"�6Q   $y�Hidden=�6d   $��Center=�6x   $
��Left=�6�   $��20(�6�   �� 6�   $-�'    Obrazlozenje zasto je lek odbijen :��6�   6�   � 5c   
   $��4��6   .+�5d      �� $��RightToLeft=�6   $ 
Horizontal=�65   .+�5f      �� -
   5         ��Name$ componentsButton��5f   �    � ToolTip$ Prikaz Sastojaka leka ��6   $��Sastojci��6;   ���#005555$��Candara)�6d   $
��Bold"�6y   
�������${�False��6�   $��	30,20,0,0q�6�   $	��100��6�   $��30��6�   $��15(�6�   ��6  Z� 6  �� 5g      -   5        $ acceptButton��5g   �   $ Odobravanje leka��6   $��Odobri��65   ���#005555$��Candara)�6\   $
��Bold"�6q   
�������${�False��6�   $��	30,20,0,0q�6�   $	��100��6�   $��30��6�   $��15(�6�   ��6�   Z� 6  �� 5h      -   5        $ declineButton��5h   �   $ Odbijanje leka��6   $��Odbij��63   ���#005555$��Candara)�6Y   $
��Bold"�6n   
�������${�False��6�   $��	30,20,0,0q�6�   $	��100��6�   $��30��6�   $��15(�6�   ��6�   Z� 6  �� 5i      -   5        $ DescriptionTextBox��5i      $��0��66   $y�Hidden=�6D   $��LeftToRight=�6X   $	��Top=�6t   $
 Left=�6�   $��30,0,0,0q�6�   $	��200��6�   $��60��6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn$
 True��5j      5m      5o      5r      5s      