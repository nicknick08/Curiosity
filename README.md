# Curiosity
ml-agents curiosity
This is for my Ml-agent study And this is curiosity environment.

This is making the AI have a curiosity to find how to get a point.
The red zone is the checkpoint. When the box(ai) enter to the red zone, the red zone will be the start point at the same time it is the goal.
and the Ai needs to walk a round the square box in a anticlockwise direction. When it complete the walk a round, it gets 2 points.
if he run in a clockwise direction and enter the red zone. it will get -1 point.
Also, if he didn't touch other red zone. it will -0.01point per second, because of the curiosity.

--------------------------------------------------------------------------------
これはml-agentsの勉強のために作りましたAIです。AIのcuriosity（好奇心）を保つための環境を作っています。
AIの好奇心を常に保てポイントを得る方法を探す。
環境内の赤いエリアはチェックポイントで、触ったらはじまります、そして、終点もこの赤いエリアになります。
AIの動きはが真ん中の正方形を回って反時計回りに一周すること。一周したら、AIが2ポイントを得られます。
しかし、時計回りに動き赤いエリアを触ったら１ポイント減点します。
それに、一秒こと赤いエリアを触らない場合は0.01ポイント減点します。好奇心を保つための設定です。

----------------------------------------------------------------------------------

中にはEXEがあります。そのAIの学習結果と学習環境を見えます。
