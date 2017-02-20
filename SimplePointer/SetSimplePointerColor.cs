// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Set simple pointer laser colors.")]

	public class  SetSimplePointerColor : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SimplePointer))]    

		public FsmOwnerDefault gameObject;

		[Tooltip("Set pointer hit laser color.")]
		[TitleAttribute("Hit Color")]

		public FsmColor hitcolorlazer;

		[Tooltip("Set point miss laser color.")]
		[TitleAttribute("Miss Color")]
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

			theScript.pointerHitColor = hitcolorlazer.Value;
			theScript.pointerMissColor = misscolorlazer.Value;

		}

	}
}



