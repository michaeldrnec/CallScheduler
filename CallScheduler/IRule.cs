namespace CallScheduler {
    interface IRule
    {
        bool Applies(Slot slot, Doctor doctor);
    }
}
