<template>
    <div class="calendar-navigator">
        <CardButton @click="handleTodayClick()" 
        class="calendar-navigator-label-today" text="Today" :style="navBarStyle.todayButton" />
        <IconButton @click="() => changeMonth(false)" :style="navBarStyle.calendarNavigationButton"
            :icon="Icons.LeftArrow" />
        <IconButton @click="() => changeMonth(true)" :style="navBarStyle.calendarNavigationButton"
            :icon="Icons.RightArrow" />
        <CardButton class="calendar-navigator-label" :text="month" :style="navBarStyle.dateNavigationButton" />
        <CardButton class="calendar-navigator-label" :text="year" :style="navBarStyle.dateNavigationButton" />
    </div>
</template>

<script setup lang="ts">
import { Icons } from '../../models/icons/Icons';
import IconButton from '../reusable/IconButton.vue';
import { computed } from '@vue/reactivity';
import { useCalendarStore } from '../../stores/calendar';
import { useStyleStore } from '../../stores/style';
import CardButton from '../reusable/CardButton.vue';
import { DateTime } from '../../models/common/DateTime';

const calendarStore = useCalendarStore()
const navBarStyle = computed(() => useStyleStore().sectionStyles.navBar)

const month = computed(() => calendarStore.selectedDate.getMonthAsString())
const year = computed(() => calendarStore.selectedDate.getYearAsString())

const changeMonth = (increment: boolean) => {
    if (increment) {
        calendarStore.incrementMonth()
    } else {
        calendarStore.decrementMonth()
    }
}

const handleTodayClick = () => {
    calendarStore.setSelectedDate(DateTime.fromNow().setDayOfMonth(0))
}
</script>

<style scoped>
.calendar-navigator {
    display: flex;
    align-items: center;
    padding: 4px;
}

.calendar-navigator-label {
    font-size: small;
    padding-right: 4px;
    padding-left: 4px;
}

.calendar-navigator-label-today {
    font-size: small;
    padding-right: 8px;
    padding-left: 8px;
}

</style>