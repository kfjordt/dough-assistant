import { reactive, readonly } from 'vue';
import { UserState } from './UserState';
import { TooltipState } from './TooltipState';

type StoreState = {
    userState: UserState
    tooltipState?: TooltipState
}
const state = reactive<StoreState>({
    userState: { isLoggedIn: false }
});

const mutations = {
    setUserState(newUserState: UserState) {
        state.userState = newUserState
    },
    setTooltipState(newTooltipState: TooltipState) {
        state.tooltipState = newTooltipState
    }
};

const actions = {
    setCurrentlyLoggedInUser(email: string, bearerToken: string) {
        mutations.setUserState({
            isLoggedIn: true,
            email: email, 
            bearerToken: bearerToken})
    },
    setUserToLoggedOut() {
        mutations.setUserState({
            isLoggedIn: false
        })
    }, 
    setTooltip(tooltip: TooltipState) {
        mutations.setTooltipState(tooltip)
    }
};

const store = readonly({
    state,
    mutations,
    actions,
});

export default store;
