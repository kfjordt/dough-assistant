import { reactive, readonly } from 'vue';
import { UserState } from './UserState';
import { TooltipState, Tooltip } from './TooltipState';
import { HtmlBoundingBox } from '../models/geometry/HtmlBoundingBox';
import { CalendarState } from './CalendarState';
import { DateTime } from '../models/common/DateTime';
import { StyleState } from './StyleState';
import { ColorPalette, getPalette } from '../models/style/ColorPalette';
import { standardTextSizeFactors, standardRoundedCornerSizes } from '../models/style/StandardSizeFactors';
import { getSectionStyles } from '../models/style/SectionStyles';
import { ColorWrapper } from '../models/style/ColorWrapper';
import { defineStore } from 'pinia'

export type StoreState = {
    userState: UserState
    tooltipState: TooltipState
    calendarState: CalendarState
    styleState: StyleState
}

const intialState: StoreState = {
    userState: { isLoggedIn: true },
    tooltipState: { isTooltipLoaded: false, tooltipTimeoutId: null },
    calendarState: { selectedDate: DateTime.fromNow() },
    styleState: { mode: "dark" }
}


const getters = {
    style: (state) => {
        return getSectionStyles(getPalette((state as StoreState).styleState.mode))
    },
    currentCalendarState: (state) => {
        return (state as StoreState).calendarState.selectedDate
    },
    currentTooltipState: (state) => {
        return (state as StoreState).tooltipState
    }
}

const actions = {
    setCurrentlyLoggedInUser(email: string, bearerToken: string) {
        (this as StoreState).userState = {
            isLoggedIn: true,
            email: email,
            bearerToken: bearerToken
        }
    },
    setUserToLoggedOut() {
        (this as StoreState).userState = {
            isLoggedIn: false
        }
    },
    clearTooltipTimeout() {
        const timeoutId = (this as StoreState).tooltipState.tooltipTimeoutId
        if (timeoutId !== null) {
            clearTimeout(timeoutId)
        }
    },
    setTooltip(tooltip: Tooltip, elementBb: HtmlBoundingBox) {
        const tooltipTimeoutId = setTimeout(() => {
            (this as StoreState).tooltipState = {
                isTooltipLoaded: true,
                tooltip: tooltip,
                anchorElement: elementBb,
                tooltipTimeoutId: null
            }
        }, 500)

    },
    closeTooltip() {
        (this as StoreState).tooltipState = {
            isTooltipLoaded: false,
            tooltipTimeoutId: null
        };
    },
    incrementMonth() {
        (this as StoreState).calendarState.selectedDate.addMonths(1)
    },
    decrementMonth() {
        (this as StoreState).calendarState.selectedDate.addMonths(-1)
    },
    toggleDarkMode() {
        (this as StoreState).styleState.mode = "dark"
    }
};

export const useStore = defineStore('store', {
    state: () => intialState,
    getters: getters,
    actions: actions
})

