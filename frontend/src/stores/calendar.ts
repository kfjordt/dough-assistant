import { computed, ref } from 'vue';
import { defineStore } from 'pinia';
import { DateTime } from '../models/common/DateTime';

export const useCalendarStore = defineStore('calendar', () => {
    const selectedDate = ref<DateTime>(DateTime.fromNow().setDayOfMonth(0));

    const incrementMonth = () => {
        const newModel = selectedDate.value.addMonths(1).getModel()
        newModel.setDate(1)
        selectedDate.value = DateTime.fromDate(newModel)
    }

    const decrementMonth = () => {
        const newModel = selectedDate.value.addMonths(-1).getModel()
        newModel.setDate(1)
        selectedDate.value = DateTime.fromDate(newModel)
    }

    const daysInCurrentMonth = computed(() => {
        const days = selectedDate.value.getDaysInCurrentMonth()
        return days
    });

    return {
        selectedDate,
        incrementMonth,
        decrementMonth,
        daysInCurrentMonth,
    };
});