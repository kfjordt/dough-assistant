import { reactive, readonly } from 'vue';
import { UserState } from './UserState';
import { TooltipState, Tooltip } from './TooltipState';
import { HtmlBoundingBox } from '../models/geometry/HtmlBoundingBox';
import { CalendarState } from './CalendarState';
import { DateTime } from '../models/common/DateTime';

type StoreState = {
    userState: UserState
    tooltipState: TooltipState
    calendarState: CalendarState
}
const state = reactive<StoreState>({
    userState: { isLoggedIn: true },
    tooltipState: { isTooltipLoaded: false, tooltipTimeoutId: null },
    calendarState: {
        selectedDate: DateTime.fromNow()
    }
});

const mutations = {
    setUserState(newUserState: UserState) {
        state.userState = newUserState;
    },
    setTooltipState(newTooltipState: TooltipState) {
        state.tooltipState = newTooltipState
    },
    clearTooltipTimeout() {
        if (state.tooltipState.tooltipTimeoutId !== null) {
            clearTimeout(state.tooltipState.tooltipTimeoutId);
            state.tooltipState.tooltipTimeoutId = null;
        }
    },
    setCalendarState(newCalendarState: CalendarState) {
        state.calendarState = newCalendarState
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
        mutations.clearTooltipTimeout();
        const tooltipTimeoutId = setTimeout(() => {
            mutations.setTooltipState({
                isTooltipLoaded: true,
                tooltip: tooltip,
                anchorElement: elementBb,
                tooltipTimeoutId: null
            });
        }, 500);

        mutations.setTooltipState({
            isTooltipLoaded: false,
            tooltipTimeoutId: tooltipTimeoutId
        });
    },
    closeTooltip() {
        mutations.clearTooltipTimeout();

        mutations.setTooltipState({
            isTooltipLoaded: false,
            tooltipTimeoutId: null
        });
    },
    incrementMonth() {
        mutations.setCalendarState({
            selectedDate: state.calendarState.selectedDate.addMonths(1)
        })
    },
    decrementMonth() {
        mutations.setCalendarState({
            selectedDate: state.calendarState.selectedDate.addMonths(-1)
        })
    }
};

const store = readonly({
    state,
    mutations,
    actions,
});

export default store;
