   M S B A M L   `   `   `  ����M  IMultithread solver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Multithread_solverMultithread_solver  5   	   #    Multithread_solver.TaskWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Multithread_solver     5   	     � Title$  
TaskWindow��5   	   $	��250��6   $	��292��6)    � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � $��10q�6   .+�5   
   �� -   5         ��Name$ lowValue��5      $
��Left=�6$   $��23��6?   $��
119,10,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ 	highValue��5      $
��Left=�6%   $��23��6@   $��
119,39,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $ n��5      $
��Left=�6   $��23��68   $��
119,68,0,0q�6D   $
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��120��6�   �� 5   
   -   5         ��Name$ label1��5      $��	Low value��6    $
��Left=�64   $��23��6O   $��	22,10,0,0q�6[   $	��Top=�6n   $��92��6�   �� 5   
   -   5        $ label2��5      $��
High value��6    $
��Left=�65   $��23��6P   $��	22,38,0,0q�6\   $	��Top=�6o   $��92��6�   �� 5   
   -   5        $ label3��5      $
��Step��6    $
��Left=�6/   $��23��6J   $��	22,68,0,0q�6V   $	��Top=�6i   $��92��6�   �� 5   
   -   5         ��Name$ ok_btn��5       �� 	IsDefault . $��OK��62   $
��Left=�6?   $��
22,144,0,0q�6Z   $	��Top=�6n   $��75��6�   6�   �� 5   
   -   5        $ 
cancel_btn��5       �� IsCancel . $��Cancel��65   $
��Left=�6F   $��133,144,0,0q�6a   $	��Top=�6v   $��75��6�   5      5      