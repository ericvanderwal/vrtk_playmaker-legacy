// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set Interact with Objects with simple pointer.")]

	public class  SetSimplePointerInteractWithObjects : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SimplePointer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Interact with Objects")]
		public FsmBool interTip;

		public FsmBool everyFrame;

		VRTK.VRTK_SimplePointer theScript;

		public override void Reset()
		{

			gameObject = null;
			interTip = false;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);


			theScript = go.GetComponent<VRTK.VRTK_SimplePointer>();

			if (!everyFrame.Value)
			{
				MakeItSo();
				Finish();
			}

		}

		public override void OnUpdate()
		{
			if (everyFrame.Value)
			{
				MakeItSo();
			}
		}


		void MakeItSo()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}

			theScript.interactWithObjects = interTip.Value;

		}

	}
}

