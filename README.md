# BlockBreaker

# このリポジトリの概要

技術書典14の新刊「Unity初心者がUniRxとDOTweenに苦戦しながらブロックくずしゲームをリファクタリングする」　のために作成したリポジトリです。
Unity2Dでブロックくずしを作っています。
詳細は下記の技術書をご覧ください。

https://techbookfest.org/product/jB2Fabv81T4pyefxbA7xnK

# unityroom

下記のページで実際に遊べます。
微妙にバグが残っており、全部ブロックをくずさなくてもクリアしちゃうことがあります。
こっそり直しますので、現時点ではそういうものとして受けいれてください。

https://unityroom.com/games/simpleblockbreaker

# お問い合せ

何かあったらTwitterのリプでどうぞ。

https://twitter.com/fujimiyanatsuki

# 履歴

2023/05/20 
unityroomへゲームを公開しました。
Ballが途中めっちゃ遅くなる事象がありましたが、BallについているRigidBody2DのCollisionDetectionなる値をContinuousに変更したら、多分直りました。
