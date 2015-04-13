private var speed : Vector3 = Vector3 (0, -1, 0);
var i:int=0;
var j:int=1;
function Update() 
{
	if(this.transform.tag=="main"&&i==0)
	{
		rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime);//向下运动
	}
	 if (i==1&&this.transform.tag=="main") //手指抬起 触控结束
 	 {
  		rigidbody.MovePosition(rigidbody.position - speed * Time.deltaTime);
	 }
 	if(Input.GetKey(KeyCode.Escape))//为返回键添加监听
    {
  		Application.Quit();//退出程序
 	}
}

function OnCollisionEnter(coll:Collision)//碰撞监听事件
{
	if(coll.collider.tag=="ball")//与球发生触碰
	{
		i=1;
		this.rigidbody.freezeRotation=false;//冻结机械手
	}
}
