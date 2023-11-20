<template>
    <div class="calendar-navigator">
        <CardButton @click="handleTodayClick()" class="calendar-navigator-label-today" text="Today"
            :style="navBarStyle.todayButton" />

        <IconButton @click="() => changeMonth(false)" :style="navBarStyle.calendarNavigationButton"
            :icon="Icons.LeftArrow" />
        <IconButton @click="() => changeMonth(true)" :style="navBarStyle.calendarNavigationButton"
            :icon="Icons.RightArrow" />

        <Dropdown @clickOutside="handleMonthClick(false)" :showDropdown="showMonthDropdown"
            class="calendar-navigator-card-button-container">
            <CardButton @click="handleMonthClick(true)" class="calendar-navigator-card-button" :text="month"
                :style="navBarStyle.dateNavigationButton" />
            <template v-slot:dropdown-content>
                <MonthNavigator @monthClicked="handleMonthClick(false)" />
            </template>
        </Dropdown>

        <Dropdown @clickOutside="handleYearClick(false)" :showDropdown="showYearDropdown"
            class="calendar-navigator-card-button-container">
            <CardButton @click="handleYearClick(true)" class="calendar-navigator-card-button" :text="year"
                :style="navBarStyle.dateNavigationButton" />
            <template v-slot:dropdown-content>
                <YearNavigator @yearClicked="handleYearClick(false)" />
            </template>
        </Dropdown>
    </div>
</template>

<script setup lang="ts">
import Dropdown from '../reusable/Dropdown.vue';
import MonthNavigator from "./MonthNavigator.vue"
import YearNavigator from "./YearNavigator.vue"
import { Icons } from '../../models/icons/Icons';
import IconButton from '../reusable/IconButton.vue';
import { computed } from '@vue/reactivity';
import { useCalendarStore } from '../../stores/calendar';
import { useStyleStore } from '../../stores/style';
import CardButton from '../reusable/CardButton.vue';
import { DateTime } from '../../models/common/DateTime';
import { ref } from 'vue';

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

const showMonthDropdown = ref(false)
const handleMonthClick = (showDropdown: boolean) => {
    showMonthDropdown.value = showDropdown
}

const showYearDropdown = ref(false)
const handleYearClick = (showDropdown: boolean) => {
    showYearDropdown.value = showDropdown
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

.calendar-navigator-card-button {
    font-size: small;
    padding: 8px;
}

.calendar-navigator-label-today {
    font-size: small;
    padding: 8px;
}</style>