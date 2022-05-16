using Spine;
using Spine.Unity;

namespace Game.Animals
{
    public class PigAnimationHandler : IAnimalAnimationHandler
    {
        private SkeletonAnimation animation;
        private SkeletonDataAsset skeletonAnimationSkeletonDataAsset;
        private const string SkinName = "Pig_pink";

        public void SetUpAnimation(SkeletonAnimation animation, SkeletonDataAsset skeletonDataAsset)
        {
            this.animation = animation;
            skeletonAnimationSkeletonDataAsset = skeletonDataAsset;
            
            this.animation.skeletonDataAsset = skeletonAnimationSkeletonDataAsset;
            this.animation.initialSkinName = SkinName;
            this.animation.Initialize(true);
        }

        public void PlayAnimation(string name, bool isLoop = false)
        {
            
        }

        public void PlayAnimation(int id, bool isLoop = false)
        {
            
        }
        

        public void PlayIdleAnimation()
        {
            animation.loop = true;
            animation.AnimationName = "Idle";
        }

        public void PlaySadAnimation()
        {
            animation.loop = true;
            animation.AnimationName = "Sad";
        }

        public void PlayHappyAnimation()
        {
            animation.loop = false;
            animation.AnimationName = "Happy_Jump";
        }

        public void SetTailAttachment(Attachment attachment) => animation.Skeleton.FindSlot("Tail").Attachment = attachment;


        public Attachment GetTailAttachment(SkeletonData skeletonData)
        {
            SlotData slot = skeletonData.FindSlot("Tail");
            return skeletonData.FindSkin(SkinName).GetAttachment(slot.Index, "Pig_pink/Tail");
        }
    }
}