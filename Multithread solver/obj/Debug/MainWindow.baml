   M S B A M L   `   `   `  ����M  ISystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089M3clr-namespace:System.ComponentModel;assembly=SystemSystem.ComponentModel  5   	   M IMultithread solver, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Multithread_solverMultithread_solver 5   	   #   Multithread_solver.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Dthrd3clr-namespace:System.ComponentModel;assembly=System     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Multithread_solver     5   	     � WindowStartupLocation$  CenterScreen=�5	   	    � Title$ 
MainWindow��5
   	   $	��450��6   $��573.5��6)    � 	Resources 5      ,   &System.ComponentModel.BackgroundWorker 
  worker   WorkerReportsProgress��%6   &	          5   
   -   5         . 5       5      .��5      � $��15q�6   .+�5   
   � -   5         �Name$ progress��5      $
��Left=�6(   $��26��6C   $��
10,337,0,0q�6O   $	��Top=�6c   $	��508��6{   �� 5   
   -   5         ��Name$ 	enter_btn��5      $��Enter the parameters��6$   $
��Left=�6C   $��
186,59,0,0q�6^   $	��Top=�6r   $	��154��6�   $��43��6�    J� RenderTransformOrigin$ 
0.512,0.12&�6�   6�   �� 5   
   -   5        $ dispatcher_btn��5      $��Use Dispatcher��6)   $
��Left=�6B   $��
35,254,0,0q�6]   $	��Top=�6q   $	��130��6�   $��55��6�   6�   �� 5   
   -   5        $ bgworker_btn��5      $��Use BackgroundWorker��6'   $
��Left=�6F   $��342,254,0,0q�6a   $	��Top=�6v   $	��130��6�   $��55��6�   6�   �� 5   
   -   5         ��Name$ image��5      $��integral.jpg��6   $
��Left=�65   $��
186,10,0,0q�6P   $	��Top=�6d   $	��154��6|   $��44��6�   �� 5   
   -   5         ��Name$	 low��5      $��	Low Value��6   $
��Left=�61   $��
60,120,0,0q�6L   $	��Top=�6`   $��70��6x   �� 5   
   -   5        $
 high��5      $��
High Value��6   $
��Left=�63   $��
60,152,0,0q�6N   $	��Top=�6b   $��70��6z   �� 5   
   -	   5        $
 step��5      $��N pieces��6   $
��Left=�61   $��
60,183,0,0q�6L   $	��Top=�6`   $��70��6x   �� 5   
   -
   5        $ lowValue��5      $�� ��6"   $
��Left=�6-   $��150,120,0,0q�6H   $	��Top=�6]   $��70��6u   �� 5   
   -   5        $ 	highValue��5      $�� ��6#   $
��Left=�6.   $��150,152,0,0q�6I   $	��Top=�6^   $��70��6v   �� 5   
   -   5        $ nValue��5      $�� ��6    $
��Left=�6+   $��150,183,0,0q�6F   $	��Top=�6[   $��70��6s   �� 5   
   -   5        $ status��5      $�� ��6    $
��Left=�6+   $��
11,308,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        $ result��5      $��Result��6    $
��Left=�61   $��
60,213,0,0q�6L   $	��Top=�6`   $��70��6x   �� 5    
   -   5        $ resultValue��5       $�� ��6%   $
��Left=�60   $��150,213,0,0q�6K   $	��Top=�6`   $��70��6x   �� 5!   
   -   5        $ dispatcher_btn_2��5!      $��Use Dispatcher Async��6+   $
��Left=�6J   $��187,254,0,0q�6e   $	��Top=�6z   $	��130��6�   $��55��6�   6�   5#      5$      