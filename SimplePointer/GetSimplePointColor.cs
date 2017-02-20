// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Get simple pointer laser colors.")]


	public class  GetSimplePointerColor : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SimplePointer))]    

		public FsmOwnerDefault gameObject;

		[Tooltip("Get pointer hit laser color.")]
		[TitleAttribute("Get Hit Color")]
		public FsmColor hitcolorlazer;

		[Tooltip("Get point miss laser color.")]
		[TitleAttribute("Get Miss Color")]
		public FsmColor misscolorlazer;

		public FsmBool everyFrame;

		VRTK.VRTK_SimplePointer theScript;

		public override void Reset()
		{
			gameObject = null;
			hitcolorlazer = null;
			misscolorlazer = null;
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

			hitcolorlazer.Value = theScript.pointerHitColor;
			misscolorlazer.Value = theScript.pointerMissColor;


		}

	}
}



