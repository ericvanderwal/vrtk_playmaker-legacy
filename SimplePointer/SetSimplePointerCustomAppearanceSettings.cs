// Custom Action by DumbGameDev

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("VRTK")]
	[Tooltip("Change simple pointer custom settings.")]

	public class  SetSimplePointerCustomAppearanceSettings : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(VRTK.VRTK_SimplePointer))]    

		public FsmOwnerDefault gameObject;

		[TitleAttribute("Customer Pointer Curser")]
		public FsmGameObject customPointer;

		[TitleAttribute("Pointer Cursor Match Target Normal")]
		public FsmBool matchTarget;

		[TitleAttribute("Pointer Cursor Rescaled Along Distance")]
		public FsmBool rescaleDistance;

		public FsmBool everyFrame;

		VRTK.VRTK_SimplePointer theScript;

		public override void Reset()
		{

			gameObject = null;
			customPointer = null;
			matchTarget = false;
			rescaleDistance = false;
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

			theScript.customPointerCursor = customPointer.Value;
			theScript.pointerCursorMatchTargetNormal = matchTarget.Value;
			theScript.pointerCursorRescaledAlongDistance = rescaleDistance.Value;

		}

	}
}
	