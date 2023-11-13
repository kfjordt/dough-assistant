import { reactive, readonly } from 'vue';
import { UserState } from './UserState';
import { TooltipState, Tooltip } from './TooltipState';
import { HtmlBoundingBox } from '../models/geometry/HtmlBoundingBox';

type StoreState = {
    userState: UserState
    tooltipState: TooltipState
}
const state = reactive<StoreState>({
    userState: { isLoggedIn: false },
    tooltipState: { isTooltipLoaded: false }
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
            bearerToken: bearerToken
        })
    },
    setUserToLoggedOut() {
        mutations.setUserState({
            isLoggedIn: false
        })
    },
    setTooltip(tooltip: Tooltip, elementBb: HtmlBoundingBox) {
        mutations.setTooltipState({
            isTooltipLoaded: true,
            tooltip: tooltip,
            anchorElement: elementBb
        })
    },
    closeTooltip() {
        mutations.setTooltipState({
            isTooltipLoaded: false
        })
    }
};

const store = readonly({
    state,
    mutations,
    actions,
});

export default store;
