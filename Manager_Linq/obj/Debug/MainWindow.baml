   M S B A M L   `   `   `  ����G  CManager_Linq, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Manager_LinqManager_Linq  5   	       Manager_Linq.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Manager_Linq     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$+ %Список користувачів��5	   	   $	��462��6%   $	��801��62    � WindowStartupLocation$ CenterScreen=�6>    � Icon$  /community_users_12977.ico��6z   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridUsers��5      $	��198��6*   $��
10,10,10,0q�67   $	��NaN��6K      AutoGenerateColumns .  $	��Top=�6s      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
id_users+  5      $ Прізвище��6%    67   �� *
LSurname+  5      $ Ім'я��6%    63   �� *LName+  5      $ По-батькові��6%    6:   �� *
LPobatkovi+  5      $ Email��6%    64   �� *LEmail+  5      $ Телефон��6%    66   �� *LPhone+  5      $# Дата народження��6%    6>   �� *
LDateBrith+5      �� 5   
   $��Прізвище:��6   $
��Left=�6$   $��
54,217,0,0q�6?   $	��Top=�6S   �� 5   
   $��Ім'я:��6   $
��Left=�6    $��
87,243,0,0q�6;   $	��Top=�6O   �� 5   
   $��По-батькові:��6   $
��Left=�6'   $��
41,269,0,0q�6B   $	��Top=�6V   �� 5   
   $��Email:��6   $
��Left=�6!   $��
79,300,0,0q�6<   $	��Top=�6P   �� 5   
   $��Телефон:��6   $
��Left=�6#   $��
60,322,0,0q�6>   $	��Top=�6R   �� 5   
   $$��Дата народження:��6   $
��Left=�6+   $��
10,348,0,0q�6F   $	��Top=�6Z   �� 5   
   -   5        	 ��Name$	 textBoxSurName��5      $��125,221,11,0q�6*   
 �� TextWrapping$

 Wrap=�6@   $	��Top=�6T   �� 5   
   -   5        $	 textBoxName��5      $��125,247,11,0q�6'   $

 Wrap=�6=   $	��Top=�6Q   �� 5   
   -   5        $	 textBoxPobatkovi��5      $��125,273,11,0q�6,   $

 Wrap=�6B   $	��Top=�6V   �� 5   
   -   5        $	 textBoxEmail��5      $��125,300,11,0q�6(   $

 Wrap=�6>   $	��Top=�6R   �� 5    
   -   5        $	 textBoxPhone��5       $��125,326,11,0q�6(   $

 Wrap=�6>   $	��Top=�6R   (  "System.Windows.Controls.DatePicker  5!   
   -   5          Name$ datePicker1��5!      $��125,350,11,0q�6*   $	��Top=�6@   �� 5"   
   -	   5         ��Name$ 	buttonAdd��5"      $��Додати��6$   $
��Left=�65   $��125,393,0,0q�6P   $	��Top=�6e   $	��112��6}   $��20��6�   6�   �� 5#   
   -
   5        $ buttonUpdate��5#      $��Змінити��6'   $
��Left=�69   $��269,393,0,0q�6T   $	��Top=�6i   $	��112��6�   6�   �� 5$   
   -   5        $ buttonDelete��5$      $��Видалити��6'   $��678,393,11,0q�6:   $	��Top=�6P   6h   �� 5%   
   -   5        $ 
buttonFind��5%      $��
Пошук��6%   $
��Left=�65   $��406,393,0,0q�6P   $	��Top=�6e   $	��102��6}   6�   �� 5&   
   -   5        $ buttonClear��5&      $!��Очистити пошук��6&   $
��Left=�6?   $��536,393,0,0q�6Z   $	��Top=�6o   $	��117��6�   6�   5'      5(      