<template>
    <div class="calendar-navigator">
        <IconButton @click="() => changeMonth(false)" :style="navBarStyle.calendarNavigationButton"
            :icon="Icons.LeftArrow" />
        <IconButton @click="() => changeMonth(true)" :style="navBarStyle.calendarNavigationButton"
            :icon="Icons.RightArrow" />
        <div class="calendar-navigator-label-container">
            <CardButton class="calendar-navigator-label" :text="month" :style="navBarStyle.dateNavigationButton" />
            <CardButton class="calendar-navigator-label" :text="year" :style="navBarStyle.dateNavigationButton" />
        </div>
    </div>
</template>

<script setup lang="ts">
import { Icons } from '../../models/icons/Icons';
import IconButton from '../reusable/IconButton.vue';
import { computed } from '@vue/reactivity';
import { useCalendarStore } from '../../stores/calendar';
import { useStyleStore } from '../../stores/style';
import CardButton from '../reusable/CardButton.vue';

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
</script>

<style scoped>
.calendar-navigator {
    display: flex;
    align-items: center;
}

.calendar-navigator-label-container {
    padding: 8px;
    display: flex
}

.calendar-navigator-label{
    padding: 4px;
}

</style>